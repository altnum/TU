import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

public class DrawCircle extends JFrame {
    public JButton button1;
    public JPanel mainPanel;
    private boolean repaint;

    public DrawCircle(String title) {
        super(title);
        setPreferredSize(new Dimension(400, 400));
        setContentPane(mainPanel);
        pack();

        repaint = false;

        button1.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                repaint = true;
                repaint();
            }
        });
    }

    public static void main(String[] args) {
        JFrame frame = new DrawCircle( "DrawCircle");
        frame.setDefaultCloseOperation(WindowConstants.EXIT_ON_CLOSE);
        frame.setVisible(true);
    }

    public void paint(Graphics g) {
        super.paint(g);
        if (repaint) {
            g.setColor(Color.RED);
            g.fillOval(Main.circle.getCenter().x + 100, Main.circle.getCenter().y + 100, Main.circle.getRadius() + 100, Main.circle.getRadius() + 100);
            g.setColor(Color.BLACK);
            Main.ls.setA(new Point(0,0));
            Main.ls.setB(new Point(300, 300));
            g.drawLine(Main.ls.getA().x, Main.ls.getA().y, Main.ls.getB().x, Main.ls.getB().y);
        }
    }

    private void createUIComponents() {
        // TODO: place custom component creation code here
    }
}
