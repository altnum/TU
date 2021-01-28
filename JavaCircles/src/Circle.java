import java.awt.*;

public class Circle {
    private Point center;
    private int radius;

    public Circle () {
        this.center = new Point(0, 0);
        this.radius = 100;
    }

    public int getRadius() {
        return radius;
    }

    public void setRadius(int radius) {
        this.radius = radius;
    }

    public Point getCenter() {
        return center;
    }

    public void setCenter(Point center) {
        this.center = center;
    }

    public boolean equals (Object o) {
        if (o instanceof Circle) {
            return ((Circle) o).center.x == this.getCenter().x && ((Circle) o).center.y == this.getCenter().y && ((Circle) o).getRadius() == this.radius;
        }
        return false;
    }

    @Override
    public String toString() {
        return this.getClass().getName() + "-> Coordinates of centre: x= " + this.center.x + ", y= " + this.center.y + ", radius= " + this.radius;
    }
}
