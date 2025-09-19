// 代码生成时间: 2025-09-20 05:56:13
using System;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Drawing.Imaging;

namespace ImageProcessing
{
    // 图片尺寸批量调整器
    public class ImageResizer
    {
        private readonly string _sourceFolder;
        private readonly string _destinationFolder;
        private readonly int _newWidth;
        private readonly int _newHeight;

        public ImageResizer(string sourceFolder, string destinationFolder, int newWidth, int newHeight)
        {
            _sourceFolder = sourceFolder;
            _destinationFolder = destinationFolder;
            _newWidth = newWidth;
            _newHeight = newHeight;
        }

        // 调整文件夹内所有图片尺寸
        public void ResizeImages()
        {
            try
            {
                var files = Directory.GetFiles(_sourceFolder, "*.*", SearchOption.AllDirectories)
                    .Where(f => IsImageFile(f))
                    .ToList();

                foreach (var file in files)
                {
                    ResizeImage(file, Path.Combine(_destinationFolder, Path.GetFileName(file)));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error resizing images: {ex.Message}");
            }
        }

        // 检查文件是否为图片
        private bool IsImageFile(string filePath)
        {
            var extension = Path.GetExtension(filePath).ToLower();
            return extension == ".jpg" || extension == ".jpeg" || extension == ".png" || extension == ".gif";
        }

        // 调整单个图片尺寸
        private void ResizeImage(string sourceFilePath, string destinationFilePath)
        {
            using (var image = Image.FromFile(sourceFilePath))
            {
                var newImage = new Bitmap(_newWidth, _newHeight);
                using (var graphics = Graphics.FromImage(newImage))
                {
                    graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                    graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                    graphics.DrawImage(image, 0, 0, _newWidth, _newHeight);
                }

                newImage.Save(destinationFilePath, image.RawFormat);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string sourceFolder = "path/to/source/folder";
                string destinationFolder = "path/to/destination/folder";
                int newWidth = 800;
                int newHeight = 600;

                var imageResizer = new ImageResizer(sourceFolder, destinationFolder, newWidth, newHeight);
                imageResizer.ResizeImages();

                Console.WriteLine("Image resizing completed.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}