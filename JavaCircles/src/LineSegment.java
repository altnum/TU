import java.awt.*;

public class LineSegment {
    private Point A;
    private Point B;

    public double slope () {
        return (this.B.y - this.A.y) * 1.0 / (this.B.x - this.A.x);
    }

    public boolean intersects (Point p) {
        double distanceAB = Math.sqrt(Math.pow(Math.abs((this.A.x - this.B.x)), 2) + Math.pow(Math.abs((this.A.y - this.B.y)), 2));
        double distanceAP = Math.sqrt(Math.pow(Math.abs((this.A.x - p.x)), 2) + Math.pow(Math.abs((this.A.y - p.y)), 2));
        double distanceBP = Math.sqrt(Math.pow(Math.abs((this.B.x - p.x)), 2) + Math.pow(Math.abs((this.B.y - p.y)), 2));

        return distanceAB == distanceAP + distanceBP;
    }

    public Point getA() {
        return A;
    }

    public void setA(Point a) {
        A = a;
    }

    public Point getB() {
        return B;
    }

    public void setB(Point b) {
        B = b;
    }

    @Override
    public String toString () {
        return this.getClass().getName() + "-> Start point= " + this.A.toString() + ", end point= " + this.B.toString();
    }
}
