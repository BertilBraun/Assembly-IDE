using System.Drawing;

namespace Assembly_Emulator
{
    static class SegmentDisplay
    {
        static void DrawHorizondalSegment(bool filled, Graphics gx, Color clr, int x, int y, int l, int w)
        {
            if (filled)
                gx.FillPolygon(new SolidBrush(clr), new Point[] {
                new Point(x, y), new Point(x + l, y-l), new Point(x+w-l, y - l),
                new Point(x +w, y),new Point(x+w-l,y+l) ,new Point(x+l,y+l)
                });
            else
                gx.DrawPolygon(new Pen(clr), new Point[] {
                new Point(x, y), new Point(x + l, y-l), new Point(x+w-l, y - l),
                new Point(x +w, y),new Point(x+w-l,y+l) ,new Point(x+l,y+l)
                });
        }

        static void DrawVerticalSegment(bool filled, Graphics gx, Color clr, int x, int y, int l, int w)
        {
            if (filled)
                gx.FillPolygon(new SolidBrush(clr), new Point[] {
                    new Point(x, y), new Point(x + l, y+l), new Point(x+l, y +w - l),
                    new Point(x , y+w),new Point(x-l,y+w-l) ,new Point(x-l,y+l)
                });
            else
                gx.DrawPolygon(new Pen(clr), new Point[] {
                    new Point(x, y), new Point(x + l, y+l), new Point(x+l, y +w - l),
                    new Point(x , y+w),new Point(x-l,y+w-l) ,new Point(x-l,y+l)
                });
        }

        public static void DrawSegments(Graphics gx, Color clr, byte display, int x, int y, int l, int w)
        {
            /// Mapping of segment
            /// 
            ///      0
            ///      __
            ///   5 |__| 1
            ///   4 |__| 2
            ///      
            ///      3

            DrawHorizondalSegment   ((display & 1 << 0) != 0, gx, clr, x + 2, y + 2, l, w);
            DrawVerticalSegment     ((display & 1 << 1) != 0, gx, clr, x + 2 + w, y + 4, l, w);
            DrawVerticalSegment     ((display & 1 << 2) != 0, gx, clr, x + 2 + w, y + 8 + w, l, w);
            DrawHorizondalSegment   ((display & 1 << 3) != 0, gx, clr, x + 2, y + 10 + 2 * w, l, w);
            DrawVerticalSegment     ((display & 1 << 4) != 0, gx, clr, x + 2, y + 8 + w, l, w);
            DrawVerticalSegment     ((display & 1 << 5) != 0, gx, clr, x + 2, y + 4, l, w);
            DrawHorizondalSegment   ((display & 1 << 6) != 0, gx, clr, x + 2, y + 6 + w, l, w);
            DrawHorizondalSegment   ((display & 1 << 7) != 0, gx, clr, x + 5 + w, y + 10 + 2 * w, l, l + 4); 
        }
    }
}
