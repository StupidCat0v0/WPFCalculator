using System.Windows; // 基础WPF类
using System.Windows.Controls; // 基础控件库
using System.Windows.Controls.Primitives; // 用于Thumb控件
using System.Windows.Documents; // 文档相关的类
using System.Windows.Input; // 输入相关的类
using System.Windows.Media; // 图形和媒体相关的类
using System.Windows.Shapes; // 形状类

// 定义一个自定义的adorner类，用于窗口的大小调整
namespace calculator.Common
{
    public class WindowResizeAdorner : Adorner // 继承自Adorner基类，用于装饰其他UI元素
    {
        // 成员变量定义了8个Thumb控件，分别代表窗口的四边和四个角落
        Thumb _leftThumb, _topThumb, _rightThumb, _bottomThumb;
        Thumb _lefTopThumb, _rightTopThumb, _rightBottomThumb, _leftbottomThumb;

        // 一个Grid来作为这些Thumb控件的容器
        Grid _grid;

        // 装饰的目标UI元素
        UIElement _adornedElement;

        // 关联的窗口，用于调整大小
        Window _window;

        public WindowResizeAdorner(UIElement adornedElement) : base(adornedElement)
        {
            _adornedElement = adornedElement;
            _window = Window.GetWindow(_adornedElement);
            //初始化thumb
            _leftThumb = new Thumb();
            _leftThumb.HorizontalAlignment = HorizontalAlignment.Left;
            _leftThumb.VerticalAlignment = VerticalAlignment.Stretch;
            _leftThumb.Cursor = Cursors.SizeWE;
            _topThumb = new Thumb();
            _topThumb.HorizontalAlignment = HorizontalAlignment.Stretch;
            _topThumb.VerticalAlignment = VerticalAlignment.Top;
            _topThumb.Cursor = Cursors.SizeNS;
            _rightThumb = new Thumb();
            _rightThumb.HorizontalAlignment = HorizontalAlignment.Right;
            _rightThumb.VerticalAlignment = VerticalAlignment.Stretch;
            _rightThumb.Cursor = Cursors.SizeWE;
            _bottomThumb = new Thumb();
            _bottomThumb.HorizontalAlignment = HorizontalAlignment.Stretch;
            _bottomThumb.VerticalAlignment = VerticalAlignment.Bottom;
            _bottomThumb.Cursor = Cursors.SizeNS;
            _lefTopThumb = new Thumb();
            _lefTopThumb.HorizontalAlignment = HorizontalAlignment.Left;
            _lefTopThumb.VerticalAlignment = VerticalAlignment.Top;
            _lefTopThumb.Cursor = Cursors.SizeNWSE;
            _rightTopThumb = new Thumb();
            _rightTopThumb.HorizontalAlignment = HorizontalAlignment.Right;
            _rightTopThumb.VerticalAlignment = VerticalAlignment.Top;
            _rightTopThumb.Cursor = Cursors.SizeNESW;
            _rightBottomThumb = new Thumb();
            _rightBottomThumb.HorizontalAlignment = HorizontalAlignment.Right;
            _rightBottomThumb.VerticalAlignment = VerticalAlignment.Bottom;
            _rightBottomThumb.Cursor = Cursors.SizeNWSE;
            _leftbottomThumb = new Thumb();
            _leftbottomThumb.HorizontalAlignment = HorizontalAlignment.Left;
            _leftbottomThumb.VerticalAlignment = VerticalAlignment.Bottom;
            _leftbottomThumb.Cursor = Cursors.SizeNESW;
            _grid = new Grid();
            _grid.Children.Add(_leftThumb);
            _grid.Children.Add(_topThumb);
            _grid.Children.Add(_rightThumb);
            _grid.Children.Add(_bottomThumb);
            _grid.Children.Add(_lefTopThumb);
            _grid.Children.Add(_rightTopThumb);
            _grid.Children.Add(_rightBottomThumb);
            _grid.Children.Add(_leftbottomThumb);
            AddVisualChild(_grid);
            foreach (Thumb thumb in _grid.Children)
            {
                int thumnSize = 5;
                if (thumb.HorizontalAlignment == HorizontalAlignment.Stretch)
                {
                    thumb.Width = 10;
                    thumb.Margin = new Thickness(thumnSize, 0, thumnSize, 0);
                }
                else
                {
                    thumb.Width = thumnSize;
                }
                if (thumb.VerticalAlignment == VerticalAlignment.Stretch)
                {
                    thumb.Height = 10;
                    thumb.Margin = new Thickness(0, thumnSize, 0, thumnSize);
                }
                else
                {
                    thumb.Height = thumnSize;
                }
                thumb.Background = Brushes.Green;
                thumb.Template = new ControlTemplate(typeof(Thumb))
                {
                    VisualTree = GetFactory(new SolidColorBrush(Colors.Transparent))
                };
                thumb.DragDelta += Thumb_DragDelta;
            }
        }

        // 重写GetVisualChild方法以支持视觉树遍历
        protected override Visual GetVisualChild(int index)
        {
            return _grid;
        }

        // 重写VisualChildrenCount属性，返回视觉子元素的数量
        protected override int VisualChildrenCount
        {
            get { return 1; }
        }
        protected override Size ArrangeOverride(Size finalSize)
        {
            //直接给grid布局，grid内部的thumb会自动布局。
            _grid.Arrange(new Rect(new Point(-(_window.RenderSize.Width - finalSize.Width) / 2,
                -(_window.RenderSize.Height - finalSize.Height) / 2), _window.RenderSize));
            return finalSize;
        }
        //拖动逻辑
        private void Thumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            var c = _window;
            var thumb = sender as FrameworkElement;
            double left, top, width, height;
            if (thumb.HorizontalAlignment == HorizontalAlignment.Left)
            {
                left = c.Left + e.HorizontalChange;
                width = c.Width - e.HorizontalChange;
            }
            else
            {
                left = c.Left;
                width = c.Width + e.HorizontalChange;
            }
            if (thumb.HorizontalAlignment != HorizontalAlignment.Stretch)
            {
                if (width > 255)                                                                                        //here窗口尺寸不可小于此值
                {
                    c.Left = left;
                    c.Width = width;
                }
            }
            if (thumb.VerticalAlignment == VerticalAlignment.Top)
            {

                top = c.Top + e.VerticalChange;
                height = c.Height - e.VerticalChange;
            }
            else
            {
                top = c.Top;
                height = c.Height + e.VerticalChange;
            }

            if (thumb.VerticalAlignment != VerticalAlignment.Stretch)
            {
                if (height > 417)                                                                                        //here窗口尺寸不可小于此值
                {
                    c.Top = top;
                    c.Height = height;
                }
            }
        }

        // 生成Thumb的样式工厂方法，这里简单地返回一个填充了指定背景色的矩形
        FrameworkElementFactory GetFactory(Brush back)
        {
            var fef = new FrameworkElementFactory(typeof(Rectangle));
            fef.SetValue(Rectangle.FillProperty, back);
            return fef;
        }
    }

}
