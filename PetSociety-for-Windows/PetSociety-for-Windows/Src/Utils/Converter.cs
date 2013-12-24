﻿﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.;
using System.Windows;
using System.Device.Location;

namespace PetSociety_for_Windows.Src.Utils
{
    class Converter
    {
        private readonly double PixelTileSize = 256d;
        private readonly double DegreesToRadiansRatio = 180d / Math.PI;
        private readonly double RadiansToDegreesRatio = Math.PI / 180d;
        private readonly Point PixelGlobeCenter;
        private readonly double XPixelsToDegreesRatio;
        private readonly double YPixelsToRadiansRatio;

        public Converter(double zoomLevel)
        {
            var pixelGlobeSize = this.PixelTileSize * Math.Pow(2d, zoomLevel);
            this.XPixelsToDegreesRatio = pixelGlobeSize / 360d;
            this.YPixelsToRadiansRatio = pixelGlobeSize / (2d * Math.PI);
            var halfPixelGlobeSize = Convert.ToSingle(pixelGlobeSize / 2d);
            this.PixelGlobeCenter = new Point(halfPixelGlobeSize, halfPixelGlobeSize);
        }

        #region IProjection Members

        public Point FromCoordinatesToPixel(GeoCoordinate coordinates)
        {
            var x = Math.Round(this.PixelGlobeCenter.X + (coordinates.X * this.XPixelsToDegreesRatio));
            var f = Math.Min(Math.Max(Math.Sin(coordinates.Y * RadiansToDegreesRatio), -0.9999d), 0.9999d);
            var y = Math.Round(this.PixelGlobeCenter.Y + .5d * Math.Log((1d + f) / (1d - f)) * -this.YPixelsToRadiansRatio);
            return new Point(Convert.ToSingle(x), Convert.ToSingle(y));
        }

        public GeoCoordinate FromPixelToCoordinates(Point pixel)
        {
            var longitude = (pixel.X - this.PixelGlobeCenter.X) / this.XPixelsToDegreesRatio;
            var latitude = (2 * Math.Atan(Math.Exp((pixel.Y - this.PixelGlobeCenter.Y) / -this.YPixelsToRadiansRatio)) - Math.PI / 2) * DegreesToRadiansRatio;
            return new GeoCoordinate(Convert.ToSingle(latitude), Convert.ToSingle(longitude));
        }

        #endregion
    }
}
