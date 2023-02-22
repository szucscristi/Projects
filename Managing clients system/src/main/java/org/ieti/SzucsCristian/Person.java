package org.ieti.SzucsCristian;
import java.util.UUID;

public class Person {

    private String id;
    private String nume;
    private String prenume;
    private String cnp;
    private String serieBuletin;
    private String soldCurent;
    private String rataLunara;

    public Person(String nume, String prenume, String cnp, String serieBuletin, String soldCurent, String rataLunara) {
        UUID uuid = UUID.randomUUID();
        this.id = uuid.toString();
        this.nume = nume;
        this.prenume = prenume;
        this.cnp = cnp;
        this.serieBuletin = serieBuletin;
        this.soldCurent = soldCurent;
        this.rataLunara = rataLunara;
    }


    public String getId(){
        return id;
    }

    public String getNume() {
        return nume;
    }

    public void setNume(String nume) {
        this.nume = nume;
    }

    public String getPrenume() {
        return prenume;
    }

    public void setPrenume(String prenume) {
        this.prenume = prenume;
    }

    public String getCnp() {
        return cnp;
    }

    public void setCnp(String cnp) {
        this.cnp = cnp;
    }

    public String getSerieBuletin() {
        return serieBuletin;
    }

    public void setSerieBuletin(String serieBuletin) {
        this.serieBuletin = serieBuletin;
    }

    public String getSoldCurent() {
        return soldCurent;
    }

    public void setSoldCurent(String soldCurent) {
        this.soldCurent = soldCurent;
    }

    public String getRataLunara() {
        return rataLunara;
    }

    public void setRataLunara(String rataLunara) {
        this.rataLunara = rataLunara;
    }
}