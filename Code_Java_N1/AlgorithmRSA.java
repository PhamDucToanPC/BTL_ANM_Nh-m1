package test;

import java.math.BigInteger;
import java.security.SecureRandom;

public class AlgorithmRSA {
    private BigInteger n, d, e;

    public AlgorithmRSA(BigInteger p, BigInteger q) {
        n = p.multiply(q);
        BigInteger phi = (p.subtract(BigInteger.ONE)).multiply(q.subtract(BigInteger.ONE));
        e = generateRandomE(phi);
        d = e.modInverse(phi);
    }

    private BigInteger generateRandomE(BigInteger phi) {
        SecureRandom random = new SecureRandom();
        BigInteger e;
        do {
            e = new BigInteger(phi.bitLength(), random);
        } while (e.compareTo(BigInteger.ONE) <= 0 || e.compareTo(phi) >= 0 || !e.gcd(phi).equals(BigInteger.ONE));
        return e;
    }

    public BigInteger getN() {
        return n;
    }

    public BigInteger getE() {
        return e;
    }

    public BigInteger getD() {
        return d;
    }
}