﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Resources;

namespace RH.Manager.Tools
{
    public static class ClientTools
    {
        public static byte[] LoadResourceAsByteArray(string resourceUri)
        {
            byte[] temp = null;
            StreamResourceInfo sri = System.Windows.Application.GetResourceStream(new Uri(resourceUri, UriKind.Relative));
            using (var streamReader = new MemoryStream())
            {
                sri.Stream.CopyTo(streamReader);
                temp = streamReader.ToArray();
            }
            return temp;
        }

        /// <summary>
		/// Gets the name of the executing assembly.
		/// </summary>
		/// <value>The name of the executing assembly.</value>
		public static string ExecutingAssemblyName
        {
            get
            {
                var name = System.Reflection.Assembly.GetExecutingAssembly().FullName;
                return name.Substring(0, name.IndexOf(','));
            }
        }

        /// <summary>
        /// Gets the stream at the given path inside the current assembly.
        /// </summary>
        /// <param name="relativeUri">
        /// The relative URI.
        /// </param>
        /// <returns>
        /// </returns>
        public static Stream GetStream(string relativeUri)
        {
            var uri = new Uri(relativeUri, UriKind.RelativeOrAbsolute);
            return GetStream(uri, ExecutingAssemblyName);
        }

        /// <summary>
        /// Gets the stream at the given path inside the current assembly.
        /// </summary>
        /// <param name="uri">
        /// The relative URI.
        /// </param>
        /// <returns>
        /// </returns>
        public static Stream GetStream(Uri uri)
        {
            return GetStream(uri, ExecutingAssemblyName);
        }

        /// <summary>
        /// Gets a bitmap inside the given assembly at the given path therein.
        /// </summary>
        /// <param name="uri">
        /// The relative URI.
        /// </param>
        /// <param name="assemblyName">
        /// Name of the assembly.
        /// </param>
        /// <returns>
        /// </returns>
        public static BitmapImage GetBitmap(Uri uri, string assemblyName)
        {
            if (uri == null)
            {
                return null;
            }

            var stream = GetStream(uri, assemblyName);

            if (stream == null)
            {
                return null;
            }

            using (stream)
            {
                var bmp = new BitmapImage();
				bmp.BeginInit();
				bmp.StreamSource = stream;
				bmp.EndInit();
                return bmp;
            }
        }

        /// <summary>
        /// Gets a bitmap inside the given assembly at the given path therein.
        /// </summary>
        /// <param name="relativeUri">
        /// The relative URI.
        /// </param>
        /// <param name="assemblyName">
        /// Name of the assembly.
        /// </param>
        /// <returns>
        /// </returns>
        public static BitmapImage GetBitmap(string relativeUri, string assemblyName)
        {
            var uri = new Uri(relativeUri, UriKind.RelativeOrAbsolute);
            return GetBitmap(uri, assemblyName);
        }

        /// <summary>
        /// Gets a bitmap in the current assembly.
        /// </summary>
        public static BitmapImage GetBitmap(string relativePath)
        {
            var uri = new Uri(relativePath, UriKind.RelativeOrAbsolute);
            return GetBitmap(uri, ExecutingAssemblyName);
        }

        /// <summary>
        /// Gets the stream in the given assembly at the specified path.
        /// </summary>
        /// <param name="uri">
        /// The relative URI.
        /// </param>
        /// <param name="assemblyName">
        /// Name of the assembly.
        /// </param>
        /// <returns>
        /// </returns>
        public static Stream GetStream(Uri uri, string assemblyName)
        {
            return uri != null ? GetStream(uri.ToString(), assemblyName) : null;
        }

        /// <summary>
        /// Gets the stream in the given assembly at the specified path.
        /// </summary>
        /// <param name="relativeUri">
        /// The relative URI.
        /// </param>
        /// <param name="assemblyName">
        /// Name of the assembly.
        /// </param>
        /// <returns>
        /// </returns>
        public static Stream GetStream(string relativeUri, string assemblyName)
        {
            try
            {
                if (Application.Current == null) return null;

                if (relativeUri.StartsWith("/", StringComparison.Ordinal)) relativeUri = relativeUri.Remove(0, 1);

                if (assemblyName.ToLower().EndsWith(".dll", StringComparison.Ordinal)) assemblyName = assemblyName.Replace(".dll", string.Empty);

                var res = Application.GetResourceStream(new Uri(assemblyName + ";component/" + relativeUri, UriKind.Relative)) ??
                          Application.GetResourceStream(new Uri(relativeUri, UriKind.Relative));

                if (res != null) return res.Stream;
            }
            catch (Exception)
            {
                return null;
            }
            return null;
        }
    }
}
