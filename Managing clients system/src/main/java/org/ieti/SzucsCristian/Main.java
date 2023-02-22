package org.ieti.SzucsCristian;

import javax.imageio.ImageIO;
import javax.swing.*;
import javax.swing.border.Border;
import javax.swing.table.DefaultTableModel;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;
import java.awt.image.BufferedImage;
import javax.swing.JScrollPane;
import java.io.File;
import java.io.IOException;
import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.ArrayList;

import static java.lang.System.console;

public class Main
{

    static int selectedRow;

    public static void main(String[] args) throws IOException {
        // FRAME

        JFrame frame=new JFrame("Banca Silver - date clienti");
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        frame.setExtendedState(JFrame.MAXIMIZED_BOTH);


        // Butoane bara
//        JMenuBar menuBar=new JMenuBar();
//        JMenu fileMenu=new JMenu("Fisier");
//        JMenu helpMenu=new JMenu("Ajutor");
//        menuBar.add(fileMenu);
//        menuBar.add(helpMenu);
//        JMenuItem openOption=new JMenuItem("Deschideti");
//        JMenuItem saveOption=new JMenuItem("Salvati ca..");
//        fileMenu.add(openOption);
//        fileMenu.add(saveOption);
//        frame.setJMenuBar(menuBar);

        // Panel
        JPanel mainPanel = new JPanel(new GridBagLayout()) {

            @Override
            public Dimension getPreferredSize() {
                return new Dimension(200, 200);
            }

        };


        JTextField text_field_nume=new JTextField(15);
        JTextField text_field_prenume=new JTextField(15);
        JTextField text_field_cnp=new JTextField(15);
        JTextField text_field_serie=new JTextField(15);
        JTextField text_field_sold=new JTextField(15);
        JTextField text_field_rata=new JTextField(15);


        JLabel text_informativ=new JLabel("Introduceti datele clientului: ");
        text_informativ.setFont(new Font("Serif", Font.BOLD, 18));


        JLabel nume_client=new JLabel("Nume      ");
        nume_client.setFont(new Font("Serif", Font.PLAIN, 18));
        JPanel text_nume_client=new JPanel();
        text_nume_client.add(nume_client);
        text_nume_client.add(text_field_nume);

        JLabel prenume_client=new JLabel("Prenume      ");
        prenume_client.setFont(new Font("Serif", Font.PLAIN, 18));
        JPanel text_prenume_client=new JPanel();
        text_prenume_client.add(prenume_client);
        text_prenume_client.add(text_field_prenume);

        JLabel cnp_client=new JLabel("CNP      ");
        cnp_client.setFont(new Font("Serif", Font.PLAIN, 18));
        JPanel text_cnp_client=new JPanel();
        text_cnp_client.add(cnp_client);
        text_cnp_client.add(text_field_cnp);

        JLabel serie_buletin_client=new JLabel("Serie buletin      ");
        serie_buletin_client.setFont(new Font("Serif", Font.PLAIN, 18));
        JPanel text_serie_client=new JPanel();
        text_serie_client.add(serie_buletin_client);
        text_serie_client.add(text_field_serie);

        JLabel sold_curent_client=new JLabel("Sold curent(lei)      ");
        sold_curent_client.setFont(new Font("Serif", Font.PLAIN, 18));
        JPanel text_sold_curent_client=new JPanel();
        text_sold_curent_client.add(sold_curent_client);
        text_sold_curent_client.add(text_field_sold);

        JLabel rata_client=new JLabel("Rata lunara(lei)      ");
        rata_client.setFont(new Font("Serif", Font.PLAIN, 18));
        JPanel text_rata_client=new JPanel();
        text_rata_client.add(rata_client);
        text_rata_client.add(text_field_rata);

        JButton send=new JButton("Introduceti datele");
        JButton delete=new JButton("Stergeti datele din panou");

        mainPanel.add(text_informativ);
        mainPanel.add(text_nume_client);
        mainPanel.add(text_prenume_client);
        mainPanel.add(text_cnp_client);
        mainPanel.add(text_serie_client);
        mainPanel.add(text_sold_curent_client);
        mainPanel.add(text_rata_client);
        mainPanel.add(send);
        mainPanel.add(delete);

        Dimension size = Toolkit. getDefaultToolkit(). getScreenSize();
        mainPanel.setBounds(size.width-500,size.height/6,size.width/4,size.height/2);

        mainPanel.setLayout(new BoxLayout(mainPanel, BoxLayout.Y_AXIS));
        mainPanel.setVisible(true);


        //Table

        JTable table = new JTable();
        Object[] columns = {"Nume","Prenume","CNP","Serie CI", "Sold curent","Rata lunara"};
        DefaultTableModel model = new DefaultTableModel();
        model.setColumnIdentifiers(columns);
        JScrollPane pane = new JScrollPane(table);
        pane.setBounds(50, size.height/6, 600, 400);
        table.getTableHeader().setReorderingAllowed(false);
        table.setModel(model);




        ArrayList<Person> persons = new ArrayList<>();
        Object[] row = new Object[6];




        JPanel buttonsPanel = new JPanel();
        JButton deletePerson = new JButton("Stergeti datele persoanei");
        JButton rataLunaraMaxima = new JButton("Rata maxima");
        JButton soldMaxim = new JButton("Sold maxim");

        buttonsPanel.add(deletePerson);
        buttonsPanel.add(rataLunaraMaxima);
        buttonsPanel.add(soldMaxim);

        buttonsPanel.setLayout(new BoxLayout(buttonsPanel, BoxLayout.Y_AXIS));

        buttonsPanel.setBounds(700,size.height/6,200,300);

        Border blackline = BorderFactory.createLineBorder(Color.black);
        mainPanel.setBorder(blackline);


        //Add image

        BufferedImage myPicture = ImageIO.read(new File("src/main/java/org/ieti/SzucsCristian/resources/bank.png"));
        JLabel picLabel = new JLabel(new ImageIcon(myPicture));

        JPanel imagePanel = new JPanel();
//        imagePanel.setSize(new Dimension( 400, 200 ));
        imagePanel.setBounds(size.width/2-298,size.height/2-207,596,415);
        imagePanel.add(picLabel);








        // placements and visibility
        frame.setLayout(null);
        frame.add(imagePanel);
        frame.add(pane);
        frame.add(buttonsPanel);
        //frame.add(pane2);

        frame.add(mainPanel);
        frame.setVisible(true);


        table.addMouseListener(new MouseAdapter(){

            @Override
            public void mouseClicked(MouseEvent e){
                selectedRow = table.getSelectedRow();


            }
        });


        deletePerson.addActionListener(new ActionListener(){
            @Override
            public void actionPerformed(ActionEvent e) {
                persons.remove(selectedRow);

                model.setRowCount(0);
                for (Person person: persons) {
                    row[0]=person.getNume();
                    row[1]=person.getPrenume();
                    row[2]=person.getCnp();
                    row[3]=person.getSerieBuletin();
                    row[4]=person.getSoldCurent();
                    row[5]=person.getRataLunara();

                    model.addRow(row);
                }
            }
        });
        soldMaxim.addActionListener(new ActionListener(){
            @Override
            public void actionPerformed(ActionEvent e) {
                int x=0;
                String max="0",persoanaNume="",persoanaPrenume="";
                model.setRowCount(0);
                for (Person person: persons) {
                    if(Integer.parseInt(person.getSoldCurent()) > Integer.parseInt(max)) {
                        max = person.getSoldCurent();
                        persoanaNume=person.getNume();
                        persoanaPrenume=person.getPrenume();
                    }
                }
                model.setRowCount(0);
                for (Person person: persons) {
                    row[0]=person.getNume();
                    row[1]=person.getPrenume();
                    row[2]=person.getCnp();
                    row[3]=person.getSerieBuletin();
                    row[4]=person.getSoldCurent();
                    row[5]=person.getRataLunara();

                    model.addRow(row);
                }
                JOptionPane.showMessageDialog(null,
                        "Soldul curent cel mai mare il detine "+persoanaNume+" "+persoanaPrenume+" :"+max+" de lei!",
                        "Soldul curent maxim",
                        JOptionPane.INFORMATION_MESSAGE);
            }
        });



        rataLunaraMaxima.addActionListener(new ActionListener(){
            @Override
            public void actionPerformed(ActionEvent e) {
                int x=0;
                String max="0",persoanaNume="",persoanaPrenume="";
                model.setRowCount(0);
                for (Person person: persons) {
                    if(Integer.parseInt(person.getRataLunara()) > Integer.parseInt(max)) {
                        max = person.getRataLunara();
                        persoanaNume=person.getNume();
                        persoanaPrenume=person.getPrenume();
                    }
                }
                model.setRowCount(0);
                for (Person person: persons) {
                    row[0]=person.getNume();
                    row[1]=person.getPrenume();
                    row[2]=person.getCnp();
                    row[3]=person.getSerieBuletin();
                    row[4]=person.getSoldCurent();
                    row[5]=person.getRataLunara();

                    model.addRow(row);
                }
                JOptionPane.showMessageDialog(null,
                        "Rata lunara cea mai mare o are "+persoanaNume+" "+persoanaPrenume+" :"+max+" de lei!",
                        "Rata lunara maxima",
                        JOptionPane.INFORMATION_MESSAGE);
            }
        });

        delete.addActionListener(new ActionListener(){
            @Override
            public void actionPerformed(ActionEvent e) {
                text_field_nume.setText("");
                text_field_prenume.setText("");
                text_field_cnp.setText("");
                text_field_serie.setText("");
                text_field_sold.setText("");
                text_field_rata.setText("");

            }
        });

        send.addActionListener(new ActionListener(){
            @Override
            public void actionPerformed(ActionEvent e) {

                Person p = new Person(text_field_nume.getText(),text_field_prenume.getText(),text_field_cnp.getText(),text_field_serie.getText(),text_field_sold.getText(),text_field_rata.getText());
                persons.add(p);

                model.setRowCount(0);
                for (Person person: persons) {
                    row[0]=person.getNume();
                    row[1]=person.getPrenume();
                    row[2]=person.getCnp();
                    row[3]=person.getSerieBuletin();
                    row[4]=person.getSoldCurent();
                    row[5]=person.getRataLunara();

                    model.addRow(row);
                }

                text_field_nume.setText("");
                text_field_prenume.setText("");
                text_field_cnp.setText("");
                text_field_serie.setText("");
                text_field_sold.setText("");
                text_field_rata.setText("");

            }
        });





    }
}