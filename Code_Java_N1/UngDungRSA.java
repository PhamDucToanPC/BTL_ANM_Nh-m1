package test;

import javax.swing.*;
import java.awt.*;
import java.math.BigInteger;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.security.MessageDigest;
import java.security.SecureRandom;
import java.util.Arrays;

public class UngDungRSA {
    private JPasswordField truongKhoaBiMat;
    private JTextField truongKhoaCongKhai;
    private JTextField truongDuLieuKy;
    private JTextArea truongChuKyKetQua;
    private JTextField truongChuKyXacThuc;
    private JTextArea truongKetQuaXacThuc;
    private JComboBox<String> comboBoxKichThuoc;

    private BigInteger khoaBiMat;
    private BigInteger khoaCongKhai;
    private BigInteger modulo;
    private byte[] hashCuoi;

    private boolean isKhoaBiMatVisible = false; // Trạng thái hiển thị của khóa bí mật

    public UngDungRSA() {
        initializeUI();
    }

    private void initializeUI() {
        JFrame cuaSo = createMainFrame();
        cuaSo.add(createKeyGenerationPanel());
        cuaSo.add(createDataSigningPanel());
        cuaSo.add(createSignatureVerificationPanel());
        cuaSo.setVisible(true);
    }

    private JFrame createMainFrame() {
        JFrame cuaSo = new JFrame("Ứng Dụng Ký Số RSA");
        cuaSo.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        cuaSo.setSize(800, 750);
        cuaSo.setLayout(new GridLayout(3, 1));
        return cuaSo;
    }

    private JPanel createKeyGenerationPanel() {
        JPanel panel = new JPanel(new GridBagLayout());
        panel.setBorder(BorderFactory.createTitledBorder("Sinh Khóa"));
        GridBagConstraints r = createGridBagConstraints();

        truongKhoaBiMat = new JPasswordField(15);
        truongKhoaBiMat.setEditable(false);
        truongKhoaBiMat.setEchoChar('•'); // Che bằng dấu tròn đen
        truongKhoaCongKhai = new JTextField(15);
        truongKhoaCongKhai.setEditable(false);

        JButton nutSinhKhoa = new JButton("Sinh Khóa");
        comboBoxKichThuoc = new JComboBox<>(new String[]{"512", "1024", "2048"});

        nutSinhKhoa.addActionListener(e -> generateKeys());

        JButton nutAnHienKhoaBiMat = new JButton("Hiện/Ẩn Khóa Bí Mật");
        nutAnHienKhoaBiMat.addActionListener(e -> togglePasswordVisibility(nutAnHienKhoaBiMat));

        addComponentsToPanel(panel, r, nutSinhKhoa, nutAnHienKhoaBiMat);
        return panel;
    }

    private void togglePasswordVisibility(JButton button) {
        if (isKhoaBiMatVisible) {
            truongKhoaBiMat.setEchoChar('•'); // Che bằng dấu tròn đen
            button.setText("Hiện Khóa");
        } else {
            truongKhoaBiMat.setEchoChar((char) 0); // Hiển thị văn bản gốc
            button.setText("Ẩn Khóa");
        }
        isKhoaBiMatVisible = !isKhoaBiMatVisible;
    }

    private void addComponentsToPanel(JPanel panel, GridBagConstraints r, JButton nutSinhKhoa, JButton nutAnHienKhoaBiMat) {
        r.gridx = 0; r.gridy = 0;
        panel.add(new JLabel("Khóa bí mật:"), r);
        r.gridx = 1; panel.add(truongKhoaBiMat, r);
        r.gridx = 2; panel.add(nutAnHienKhoaBiMat, r);

        r.gridx = 0; r.gridy = 1;
        panel.add(new JLabel("Khóa công khai:"), r);
        r.gridx = 1; panel.add(truongKhoaCongKhai, r);

        r.gridx = 0; r.gridy = 2;
        panel.add(new JLabel("Kích thước khóa:"), r);
        r.gridx = 1; panel.add(comboBoxKichThuoc, r);
        r.gridx = 2; panel.add(nutSinhKhoa, r);
    }

    private JPanel createDataSigningPanel() {
        JPanel panel = new JPanel(new GridBagLayout());
        panel.setBorder(BorderFactory.createTitledBorder("Ký Dữ Liệu"));
        GridBagConstraints r = createGridBagConstraints();

        truongDuLieuKy = new JTextField(20);
        JButton nutChonTepKy = new JButton("Chọn tệp");
        nutChonTepKy.addActionListener(e -> chonTep(truongDuLieuKy));

        truongChuKyKetQua = new JTextArea(3, 20);
        truongChuKyKetQua.setEditable(false);
        JButton nutKyDuLieu = new JButton("Ký Dữ Liệu");
        JButton nutXuatChuKy = new JButton("Xuất Chữ Ký");

        nutKyDuLieu.addActionListener(e -> kyDuLieu());
        nutXuatChuKy.addActionListener(e -> luuTep(truongChuKyKetQua.getText()));

        addSigningComponentsToPanel(panel, r, nutChonTepKy, nutKyDuLieu, nutXuatChuKy);
        return panel;
    }

    private void addSigningComponentsToPanel(JPanel panel, GridBagConstraints r, JButton nutChonTepKy, JButton nutKyDuLieu, JButton nutXuatChuKy) {
        r.gridx = 0;
        r.gridy = 0;
        panel.add(new JLabel("Dữ liệu:"), r);
        r.gridx = 1;
        panel.add(truongDuLieuKy, r);
        r.gridx = 2;
        panel.add(nutChonTepKy, r);

        r.gridx = 0;
        r.gridy = 1;
        panel.add(new JLabel("Chữ ký:"), r);
        r.gridx = 1;
        r.gridwidth = 2;
        panel.add(new JScrollPane(truongChuKyKetQua), r);

        r.gridx = 1;
        r.gridy = 2;
        r.gridwidth = 1;
        panel.add(nutKyDuLieu, r);
        r.gridx = 2;
        panel.add(nutXuatChuKy, r);
    }

    private JPanel createSignatureVerificationPanel() {
        JPanel panel = new JPanel(new GridBagLayout());
        panel.setBorder(BorderFactory.createTitledBorder("Xác Thực Chữ Ký"));
        GridBagConstraints r = createGridBagConstraints();

        truongChuKyXacThuc = new JTextField(20);
        JButton nutChonTepXacThuc = new JButton("Chọn tệp");
        nutChonTepXacThuc.addActionListener(e -> chonTep(truongChuKyXacThuc));

        truongKetQuaXacThuc = new JTextArea(6, 20);
        truongKetQuaXacThuc.setEditable(false);
        JButton nutXacThuc = new JButton("Xác Thực");
        JButton nutXuatKetQuaXacThuc = new JButton("Xuất Kết Quả");

        nutXacThuc.addActionListener(e -> xacThucChuKy());
        nutXuatKetQuaXacThuc.addActionListener(e -> luuTep(truongKetQuaXacThuc.getText()));

        addVerificationComponentsToPanel(panel, r, nutChonTepXacThuc, nutXacThuc, nutXuatKetQuaXacThuc);
        return panel;
    }

    private void addVerificationComponentsToPanel(JPanel panel, GridBagConstraints r, JButton nutChonTepXacThuc, JButton nutXacThuc, JButton nutXuatKetQuaXacThuc) {
        r.gridx = 0;
        r.gridy = 0;
        panel.add(new JLabel("Chữ ký cần xác thực:"), r);
        r.gridx = 1;
        panel.add(truongChuKyXacThuc, r);
        r.gridx = 2;
        panel.add(nutChonTepXacThuc, r);

        r.gridx = 0;
        r.gridy = 1;
        panel.add(new JLabel("Kết quả:"), r);
        r.gridx = 1;
        r.gridwidth = 2;
        panel.add(new JScrollPane(truongKetQuaXacThuc), r);

        r.gridx = 1;
        r.gridy = 2;
        r.gridwidth = 1;
        panel.add(nutXacThuc, r);
        r.gridx = 2;
        panel.add(nutXuatKetQuaXacThuc, r);
    }

    private GridBagConstraints createGridBagConstraints() {
        GridBagConstraints r = new GridBagConstraints();
        r.insets = new Insets(5, 5, 5, 5);
        return r;
    }

    private BigInteger sinhSoNguyenTo() {
        int bitLength = Integer.parseInt((String) comboBoxKichThuoc.getSelectedItem());
        return BigInteger.probablePrime(bitLength, new SecureRandom());
    }

    private void generateKeys() {
        try {
            int bitLength = Integer.parseInt((String) comboBoxKichThuoc.getSelectedItem());
            BigInteger p = BigInteger.probablePrime(bitLength / 2, new SecureRandom());
            BigInteger q = BigInteger.probablePrime(bitLength / 2, new SecureRandom());
            modulo = p.multiply(q);
            BigInteger phi = (p.subtract(BigInteger.ONE)).multiply(q.subtract(BigInteger.ONE));

            SecureRandom random = new SecureRandom();
            do {
                khoaCongKhai = new BigInteger(bitLength / 2, random);
            } while (khoaCongKhai.compareTo(BigInteger.ONE) <= 0 || khoaCongKhai.compareTo(phi) >= 0 || !khoaCongKhai.gcd(phi).equals(BigInteger.ONE));

            khoaBiMat = khoaCongKhai.modInverse(phi);

            truongKhoaCongKhai.setText(khoaCongKhai.toString());
            truongKhoaBiMat.setText(khoaBiMat.toString());

        } catch (NumberFormatException e) {
            showError("Đầu vào không hợp lệ! Vui lòng kiểm tra lại số nguyên tố.");
        } catch (Exception e) {
            showError("Đã xảy ra lỗi trong quá trình sinh khóa!");
        }
    }

    private void showError(String message) {
        JOptionPane.showMessageDialog(null, message, "Lỗi", JOptionPane.ERROR_MESSAGE);
    }

    private void showInfo(String message) {
        JOptionPane.showMessageDialog(null, message, "Thông báo", JOptionPane.INFORMATION_MESSAGE);
    }

    private void kyDuLieu() {
        try {
            String duLieuNhap = truongDuLieuKy.getText();
            // Băm dữ liệu
            hashCuoi = MessageDigest.getInstance("SHA-256").digest(duLieuNhap.getBytes(StandardCharsets.UTF_8));
            BigInteger chuKy = new BigInteger(1, hashCuoi).modPow(khoaBiMat, modulo);
            truongChuKyKetQua.setText(chuKy.toString());
        } catch (Exception e) {
            showError("Đã xảy ra lỗi trong quá trình ký dữ liệu! Vui lòng kiểm tra lại đầu vào.");
        }
    }

    private void xacThucChuKy() {
        try {
            BigInteger chuKy = new BigInteger(truongChuKyXacThuc.getText());

            // Giải mã chữ ký
            BigInteger duLieuDuocGiaiMa = chuKy.modPow(khoaCongKhai, modulo);
            byte[] duLieuGoc = duLieuDuocGiaiMa.toByteArray();

            // Băm lại dữ liệu ban đầu từ ô nhập liệu
            String duLieuNhap = truongDuLieuKy.getText();
            byte[] hashGoc = MessageDigest.getInstance("SHA-256").digest(duLieuNhap.getBytes(StandardCharsets.UTF_8));

            // So sánh dữ liệu băm đã ký với dữ liệu băm của dữ liệu gốc
            if (Arrays.equals(trimLeadingZeroes(duLieuGoc), hashGoc)) {
                showInfo("Chữ ký hợp lệ!");
                truongKetQuaXacThuc.setText(duLieuNhap);
            } else {
                showInfo("Chữ ký đã bị thay đổi!!!");
                truongKetQuaXacThuc.setText("");
            }
        } catch (Exception e) {
            showError("Đã xảy ra lỗi trong quá trình xác thực chữ ký!");
        }
    }

    private byte[] trimLeadingZeroes(byte[] data) {
        int start = 0;
        while (start < data.length && data[start] == 0) {
            start++;
        }
        return Arrays.copyOfRange(data, start, data.length);
    }

    private void luuTep(String duLieu) {
        try {
            JFileChooser fileChooser = new JFileChooser();
            int ketQua = fileChooser.showSaveDialog(null);
            if (ketQua == JFileChooser.APPROVE_OPTION) {
                Files.write(Paths.get(fileChooser.getSelectedFile().getAbsolutePath()), duLieu.getBytes());
            }
        } catch (Exception e) {
            showError("Đã xảy ra lỗi khi lưu tệp!");
        }
    }

    private void chonTep(JTextField truong) {
        JFileChooser fileChooser = new JFileChooser();
        int ketQua = fileChooser.showOpenDialog(null);
        if (ketQua == JFileChooser.APPROVE_OPTION) {
            try {
                String duLieu = new String(Files.readAllBytes(Paths.get(fileChooser.getSelectedFile().getAbsolutePath())), StandardCharsets.UTF_8);
                truong.setText(duLieu);
            } catch (Exception e) {
                showError("Đã xảy ra lỗi khi đọc tệp!");
            }
        }
    }

    public static void main(String[] args) {
        SwingUtilities.invokeLater(UngDungRSA::new);
    }
}