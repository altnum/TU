import java.awt.*;

public class Main extends Canvas {
    static Circle circle = new Circle();
    static Circle circle2 = new Circle();
    static Point p = new Point(0, 3);
    static LineSegment ls = new LineSegment();

    public static void main(String[] args) {
        //JFrame frame = new JFrame("DrawCircle");
        //frame.setContentPane(new DrawCircle().mainPanel);
        //frame.setDefaultCloseOperation(WindowConstants.EXIT_ON_CLOSE);
//
        ////System.out.println(Math.pow(p.x - circle.getCenter().x, 2) + Math.pow(p.y - circle.getCenter().y, 2) <= Math.pow(circle.getRadius(), 2));
        ////System.out.println(circle.equals(circle2));
        ////System.out.println(circle);
        ////ls.setA(new Point(0,0));
        ////ls.setB(new Point(300, 300));
        ////System.out.println(ls.intersects(p));
        ////System.out.println(ls);
//
        //Canvas canvas = new Canvas();
        //canvas.setSize(400, 400);
        //frame.paint(null);
        ////frame.add(canvas);
        //frame.pack();
        //frame.setVisible(true);
    }

    public void paint(Graphics g) {
        g.setColor(Color.RED);
        g.fillOval(circle.getCenter().x + 100, circle.getCenter().y + 100, circle.getRadius() + 100, circle.getRadius() + 100);
        g.setColor(Color.BLACK);
        g.drawLine(ls.getA().x, ls.getA().y, ls.getB().x, ls.getB().y);
    }
}
