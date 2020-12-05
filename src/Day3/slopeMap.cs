using System.Collections.Generic;
using System.IO;

namespace Day3
{
    public class SlopeMap
    {

        public SlopeMap(StreamReader sr)
        {
            _map = new List<CircBuff<char>>();

            while (!sr.EndOfStream) {
                var tmp = sr.ReadLine().ToCharArray();
                _map.Add(new CircBuff<char>(tmp.Length, tmp));
            }
        }

        public int collisionsOnTravel(int xStep, int yStep)
        {
            int collisions = 0;
            (int xPos, int yPos) = (xPos = 0, yPos = 0);

            while (yPos < _map.Count - yStep) {
                xPos = _map[yPos].PlaceIndexInBounds(xPos + xStep);
                yPos += yStep;
                if (_map[yPos][xPos] == '#') {
                    collisions++;
                }
            }

            return collisions;
        }

        private readonly List<CircBuff<char>> _map;
    }
}