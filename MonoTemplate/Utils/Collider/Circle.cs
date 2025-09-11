using Microsoft.Xna.Framework;
using System;


/// <summary>
/// Foncticonne comme Rectangle mais représente une sphere
/// </summary>
public struct Circle
{
    
    public Point Center { get; set; }
    public float Radius { get; set; }

    public Circle(Point center, float radius)
    {
        Center = center;
        Radius = radius;
    }

    /// <summary>
    /// Permet d'obtenir le diamèter
    /// </summary>
    public float Diameter => Radius * 2;

    /// <summary>
    /// Si le point est contenu dans la sphere
    /// </summary>
    /// <param name="point"></param>
    /// <returns></returns>
    public bool Contains(Point point)
    {
        return Vector2.DistanceSquared(Center.ToVector2(), point.ToVector2()) <= Radius * Radius;
    }

    /// <summary>
    /// Si le cercle en param est en collsion avec celui ci
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public bool Intersects(Circle other)
    {
        float distanceSquared = Vector2.DistanceSquared(Center.ToVector2(), other.Center.ToVector2());
        float radiusSum = Radius + other.Radius;
        return Math.Sqrt(distanceSquared) <= radiusSum ;
    }

    /// <summary>
    /// Si le rectangle en param est en collsion avec ce cercle
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public bool Intersects(Rectangle rect)
    {
        float closestX = MathHelper.Clamp(Center.X, rect.Left, rect.Right);
        float closestY = MathHelper.Clamp(Center.Y, rect.Top, rect.Bottom);


        float distanceSquared = (Center.X - closestX) * (Center.X - closestX) +
                                (Center.Y - closestY) * (Center.Y - closestY);

        return Math.Sqrt(distanceSquared) <= Radius ;
    }
}