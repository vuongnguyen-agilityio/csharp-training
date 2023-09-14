﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced.samples
{
    internal class EventBaseClassSample
    {
        // Special EventArgs class to hold info about Shapes.
        public class ShapeEventArgs : EventArgs
        {
            public ShapeEventArgs(double area)
            {
                NewArea = area;
            }

            public double NewArea { get; }
        }

        // Base class event publisher
        public abstract class Shape
        {
            protected double _area;

            public double Area
            {
                get => _area;
                set => _area = value;
            }

            // The event. Note that by using the generic EventHandler<T> event type
            // we do not need to declare a separate delegate type.
            public event EventHandler<ShapeEventArgs> ShapeChanged;

            public abstract void Draw();

            //The event-invoking method that derived classes can override.
            protected virtual void OnShapeChanged(ShapeEventArgs e)
            {
                // Safely raise the event for all subscribers
                ShapeChanged?.Invoke(this, e);
            }
        }

        public class Circle : Shape
        {
            private double _radius;

            public Circle(double radius)
            {
                _radius = radius;
                _area = 3.14 * _radius * _radius;
            }

            public void Update(double d)
            {
                _radius = d;
                _area = 3.14 * _radius * _radius;
                OnShapeChanged(new ShapeEventArgs(_area));
            }

            protected override void OnShapeChanged(ShapeEventArgs e)
            {
                // Do any circle-specific processing here.

                // Call the base class event invocation method.
                base.OnShapeChanged(e);
            }

            public override void Draw()
            {
                Console.WriteLine("Drawing a circle");
            }
        }

        public class Rectangle : Shape
        {
            private double _length;
            private double _width;

            public Rectangle(double length, double width)
            {
                _length = length;
                _width = width;
                _area = _length * _width;
            }

            public void Update(double length, double width)
            {
                _length = length;
                _width = width;
                _area = _length * _width;
                OnShapeChanged(new ShapeEventArgs(_area));
            }

            protected override void OnShapeChanged(ShapeEventArgs e)
            {
                // Do any rectangle-specific processing here.

                // Call the base class event invocation method.
                base.OnShapeChanged(e);
            }

            public override void Draw()
            {
                Console.WriteLine("Drawing a rectangle");
            }
        }

        // Represents the surface on which the shapes are drawn
        // Subscribes to shape events so that it knows
        // when to redraw a shape.
        public class ShapeContainer
        {
            private readonly List<Shape> _list;

            public ShapeContainer()
            {
                _list = new List<Shape>();
            }

            public void AddShape(Shape shape)
            {
                _list.Add(shape);

                // Subscribe to the base class event.
                shape.ShapeChanged += HandleShapeChanged;
            }

            // ...Other methods to draw, resize, etc.

            private void HandleShapeChanged(object sender, ShapeEventArgs e)
            {
                if (sender is Shape shape)
                {
                    // Diagnostic message for demonstration purposes.
                    Console.WriteLine($"Received event. Shape area is now {e.NewArea}");

                    // Redraw the shape here.
                    shape.Draw();
                }
            }
        }

        public void RunTest()
        {
            // What Sample Do?
            // 1. Create a standard way to declare events in a base class
            //Create the event publishers and subscriber
            var circle = new Circle(54);
            var rectangle = new Rectangle(12, 9);
            var container = new ShapeContainer();

            // Add the shapes to the container.
            container.AddShape(circle);
            container.AddShape(rectangle);

            // Cause some events to be raised.
            circle.Update(57);
            rectangle.Update(7, 7);

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

    }
}
/* Output:
        Received event. Shape area is now 10201.86
        Drawing a circle
        Received event. Shape area is now 49
        Drawing a rectangle
    */