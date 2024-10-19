using calculator.Common;
using calculator.View;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace calculator
{
    public partial class MainWindow : Window
    {
        //常量定义，用于窗口样式设置
        private const int WS_EX_TRANSPARENT = 0x20;
        private const int GWL_EXSTYLE = -20;

        //导入用户界面相关的Windows API函数，用于设置窗口样式
        [DllImport("user32", EntryPoint = "SetWindowLong")]
        private static extern uint SetWindowLong(IntPtr hwnd, int nIndex, uint dwNewLong);

        [DllImport("user32", EntryPoint = "GetWindowLong")]
        private static extern uint GetWindowLong(IntPtr hwnd, int nIndex);

        public MainWindow()
        {
            InitializeComponent();

            //初始化窗口时，设置openBorder的不透明度为1（完全不透明）
            openBorder.Opacity = 1;

            //可以在这里动态生成10条线并设置初始位置的代码，但当前示例中未提供
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            linestoy(1, SlantLine0);
            linestoy(1.1, SlantLine1);
            linestoy(1.2, SlantLine2);
            linestoy(1.3, SlantLine3);
            linestoy(1.4, SlantLine4);
            linestoy(1.5, SlantLine5);

            //将线条添加到合适的容器中，例如一个Grid或Canvas
            //YourParentContainer.Children.Add(SlantLine0);
            // 确保panel始终位于窗口底部
            sideCollapsed();
            belowCollapsed();

            //将装饰器添加到窗口的Content控件上
            var c = this.Content as UIElement;
            var layer = AdornerLayer.GetAdornerLayer(c);
            layer.Add(new WindowResizeAdorner(c));

            //获取Storyboard

            //查找并开始名为"FadeOutStoryboard"的Storyboard动画
            var storyboard2 = (Storyboard)FindResource("FadeOutStoryboard");
            storyboard2.Begin();
        }

        private void linestoy(double bt, Line line)
        {
            //创建旋转动画
            DoubleAnimation rotateAnimation = new DoubleAnimation();
            rotateAnimation.From = 0;
            rotateAnimation.To = 10;
            rotateAnimation.Duration = new Duration(TimeSpan.FromSeconds(0.3));
            rotateAnimation.RepeatBehavior = RepeatBehavior.Forever; //或者 RepeatBehavior.Count(1) 如果只需要播放一次

            //设置旋转动画的目标属性
            Storyboard.SetTargetProperty(rotateAnimation, new PropertyPath("(0).(1)", Line.RenderTransformProperty, RotateTransform.AngleProperty));

            //创建透明度动画
            DoubleAnimation opacityAnimation = new DoubleAnimation();
            opacityAnimation.From = 1;
            opacityAnimation.To = 0;
            opacityAnimation.Duration = new Duration(TimeSpan.FromSeconds(0.3));

            //设置透明度动画的目标属性
            Storyboard.SetTargetProperty(opacityAnimation, new PropertyPath(Line.OpacityProperty));

            //创建故事板并添加动画
            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(rotateAnimation);
            storyboard.Children.Add(opacityAnimation);

            //设置动画开始时间
            rotateAnimation.BeginTime = TimeSpan.FromSeconds(bt);
            opacityAnimation.BeginTime = TimeSpan.FromSeconds(bt);
            //启动！！！
            storyboard.Begin(line);
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            //最小化窗口
            this.WindowState = WindowState.Minimized;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            //关闭窗口
            Close();
        }

        private void MaximizeButton_Click(object sender, RoutedEventArgs e)
        {
            //切换窗口最大化/还原状态
            this.WindowState = this.WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //实现窗口拖动功能
            DragMove();
        }

        double storytime = 0.15;//动画时间
        private void Window_SizeChanged(object sender, System.EventArgs e)
        {
            //获取关闭按钮背景的Border元素，用于调整样式
            Border closeBorder = this.closebutton.Template.FindName("closeback", this.closebutton) as Border;

            // 根据窗口状态调整按钮图标、窗口圆角效果及关闭按钮的圆角
            if (this.WindowState == WindowState.Maximized)
            {
                maxbutton.Content = "\ue60f"; // 设置最大化图标
                Effect.CornerRadius = new CornerRadius(0); // 设置窗口圆角为0
                Effect.Margin = new Thickness(7.3); // 设置窗口边缘内边距
                closeBorder.CornerRadius = new CornerRadius(0, 0, 0, 0); // 非全屏时关闭按钮的圆角设置
            }
            else
            {
                maxbutton.Content = "\ue6a8"; // 设置非最大化图标
                Effect.CornerRadius = new CornerRadius(5); // 恢复窗口圆角为5
                Effect.Margin = new Thickness(1); // 恢复窗口边缘内边距
                closeBorder.CornerRadius = new CornerRadius(0, 5, 0, 0); // 全屏时关闭按钮的圆角设置
            }

            size();

            // 确保panel始终位于窗口底部
            sideCollapsed();
            belowCollapsed();
        }

        struct History
        {
            public string recordtexts;
            public string maintexts;
        }

        decimal op1 = 0;
        string symbol = "";
        int mod = 1;
        bool firstmod = false;
        bool equal = false;

        //数字输入
        void num(int num)
        {
            switch (mod)
            {
                case 1:
                    maintext.Text = num.ToString();
                    mod = 2;
                    break;
                case 3:
                case 5:
                    maintext.Text = num.ToString();
                    mod = 4;
                    break;
                case 2:
                case 4:
                    maintext.Text += num.ToString();
                    break;
                case 6:
                    firstmod = false;
                    equal = false;
                    op1 = 0;
                    mod = 2;
                    recordtext.Text = "";
                    maintext.Text = num + "";
                    break;
            }
        }

        //数字
        private void btn1_Click(object sender, EventArgs e) { num(1); }
        private void btn2_Click(object sender, EventArgs e) { num(2); }
        private void btn3_Click(object sender, EventArgs e) { num(3); }
        private void btn4_Click(object sender, EventArgs e) { num(4); }
        private void btn5_Click(object sender, EventArgs e) { num(5); }
        private void btn6_Click(object sender, EventArgs e) { num(6); }
        private void btn7_Click(object sender, EventArgs e) { num(7); }
        private void btn8_Click(object sender, EventArgs e) { num(8); }
        private void btn9_Click(object sender, EventArgs e) { num(9); }
        private void btn0_Click(object sender, EventArgs e) { num(0); }

        //负
        private void btnbur_Click(object sender, EventArgs e)
        {
            maintext.Text = double.Parse(maintext.Text) * -1 + "";//奇怪的正负转换
        }
        //点
        private void btnDot_Click(object sender, EventArgs e)
        {
            if (!maintext.Text.Contains("."))//奇怪的检验小数
                maintext.Text += ".";
            if (mod == 1)
                mod = 4;
        }

        //c 清除全部
        private void btnC_Click(object sender, EventArgs e)
        {
            firstmod = false;
            equal = false;
            op1 = 0;
            mod = 1;
            recordtext.Text = "";
            maintext.Text = "0";
        }
        //ce 清除输入
        private void btnCE_Click(object sender, EventArgs e) { maintext.Text = "0"; }

        //运算符号
        void mode(string mode)
        {
            if (mod == 1 || mod == 2 || mod == 3 || mod == 5 || mod == 6)
            {
                if (mode == "=")
                {
                    recordtext.Text += maintext.Text + "=";
                    mod = 6;
                    Record_refresh();
                }
                else
                    mod = 3;
                symbol = mode;
                recordtext.Text = maintext.Text + mode;
                op1 = decimal.Parse(maintext.Text);
            }
            else if (mod == 4)
            {
                mod = 5;
                string mt2 = maintext.Text;
                switch (symbol)
                {
                    case "+": // 当symbol为"+"时
                              // 执行加法运算，并将结果转换为字符串赋值给maintext.Text
                        maintext.Text = (op1 + decimal.Parse(maintext.Text)) + "";
                        break; // 完成当前case处理后退出switch
                    case "-": // 当symbol为"-"时
                              // 执行减法运算
                        maintext.Text = (op1 - decimal.Parse(maintext.Text)) + "";
                        break;
                    case "×":
                        maintext.Text = (op1 * decimal.Parse(maintext.Text)) + "";
                        break;
                    case "÷":
                        maintext.Text = (op1 / decimal.Parse(maintext.Text)) + "";
                        break;
                }
                if (mode == "=")
                {
                    recordtext.Text += mt2 + "=";
                    mod = 6;
                    Record_refresh();
                }
                if (mode != "=")
                {
                    recordtext.Text += mt2 + "=";
                    Record_refresh();
                    recordtext.Text = maintext.Text + mode;
                }
            }

            op1 = decimal.Parse(maintext.Text);
        }
        //+
        private void btnAdd_Click(object sender, EventArgs e) { mode("+"); }
        //-
        private void btnSub_Click(object sender, EventArgs e) { mode("-"); }
        //*
        private void btnMul_Click(object sender, EventArgs e) { mode("×"); }
        // /
        private void btnDiv_Click(object sender, EventArgs e) { mode("÷"); }
        // =
        private void btnEqual_Click(object sender, EventArgs e) { mode("="); }

        // 当退格键对应的按钮被点击时触发此方法
        private void btnremove_Click(object sender, EventArgs e)
        {
            // 如果显示文本长度为2，假设显示的是负数，将其转为正数
            if (maintext.Text.Length == 2)
                maintext.Text = Math.Abs(double.Parse(maintext.Text)) + "";
            // 如果显示文本长度大于1，移除最后一个字符
            if (maintext.Text.Length > 1)
                maintext.Text = maintext.Text.Substring(0, maintext.Text.Length - 1);
            // 如果仅剩一个字符，重置为0
            else if (maintext.Text.Length == 1)
                maintext.Text = "0";
        }

        // 执行x分之1的运算
        private void butquarter_Click(object sender, EventArgs e)
        {
            // 记录操作历史到recordtext
            recordtext.Text = "1/(" + maintext.Text + ")";
            // 计算并更新显示结果
            maintext.Text = "" + 1 / double.Parse(maintext.Text);
        }

        // 执行次方运算，这里默认为平方
        private void butsquare_Click(object sender, EventArgs e)
        {
            // 记录操作历史
            recordtext.Text = "sqr(" + maintext.Text + ")";
            // 计算并更新显示结果
            maintext.Text = "" + Math.Pow(double.Parse(maintext.Text), 2);
        }

        // 执行平方根运算
        private void butradicalsign_Click(object sender, EventArgs e)
        {
            // 记录操作历史
            recordtext.Text = "√(" + maintext.Text + ")";
            // 计算并更新显示结果
            maintext.Text = "" + Math.Sqrt(double.Parse(maintext.Text));
        }

        // 将当前数值转换为百分比
        private void btnpercent_Click(object sender, RoutedEventArgs e)
        {
            // 记录操作历史
            recordtext.Text = maintext.Text + "%";
            // 计算并更新显示结果为百分比
            maintext.Text = "" + double.Parse(maintext.Text) / 100;
        }


        // 刷新历史记录显示
        private void Record_refresh()
        {
            historyControl historyControls = new historyControl(); // 创建一个新的历史记录项控件实例
            historyControls.rnum.Text = recordtext.Text;
            historyControls.mnum.Text = maintext.Text;

            // 保存现有历史记录项的副本，以便稍后重新添加
            var backupElements = new List<historyControl>(r.Children.Count);
            foreach (historyControl child in r.Children)
            {
                backupElements.Add(child);
            }
            // 清空现有显示的历史记录项
            r.Children.Clear();
            // 将新创建的历史记录项添加到显示列表中
            r.Children.Add(historyControls);
            // 将之前保存的历史记录项重新添加回显示列表
            foreach (historyControl child in backupElements)
            {
                r.Children.Add(child);
            }
        }

        // 鼠标按下历史记录项时的处理
        private void bMouseDown(historyControl b)
        {
            // 当点击历史记录项时，将对应的操作和结果反映到主界面
            maintext.Text = b.mnum.Text;
            recordtext.Text = b.rnum.Text;
        }

        // 删除所有历史记录的按钮点击处理
        private void delete_Click(object sender, EventArgs e) { r.Children.Clear(); }// 清空历史记录显示区域

        // 主显示区域文本改变时的处理
        private void maintext_Change(object sender, EventArgs e) { size(); }// 调整字体大小以适应文本长度和窗口宽度

        // 自动调整字体大小的方法
        void size()
        {
            // 计算新的字体大小以适应文本内容
            float w = (float)((this.Width / (maintext.Text.Length + 1) + 0.2) / 0.6);
            // 根据计算结果限制字体大小在10到34之间
            if (w > 34)
                maintext.FontSize = 34;
            else if (w < 10)
                maintext.FontSize = 10;
            else
                maintext.FontSize = w;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            string label;
            switch (e.Key)
            {
                case Key.Enter: // 如果按下的是Enter键
                    btnEqual_Click(sender, e); // 触发等于按钮的点击事件
                    break;

                // 对应数字键0-9的操作
                case Key.D0: btn0_Click(sender, e); break;
                case Key.D1: btn1_Click(sender, e); break;
                case Key.D2:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift) // 检查Shift键是否同时按下
                        butradicalsign_Click(sender, e); // 如果是，则触发平方根按钮事件
                    else
                        btn2_Click(sender, e); // 否则，触发数字2的按钮事件
                    break;
                case Key.D3: btn3_Click(sender, e); break;
                case Key.D4: btn4_Click(sender, e); break;
                case Key.D5:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift)
                        btnpercent_Click(sender, e);
                    else
                        btn5_Click(sender, e);
                    break;
                case Key.D6: btn6_Click(sender, e); break;
                case Key.D7: btn7_Click(sender, e); break;
                case Key.D8:
                    sidepanel.Margin = new Thickness(0, 0, this.Width, 0);
                    belowpanel.Margin = new Thickness(0, this.Height, 0, 0);
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift)
                        btnMul_Click(sender, e);
                    else
                        btn8_Click(sender, e); break;
                case Key.D9: btn9_Click(sender, e); break;


                case Key.Q: butsquare_Click(sender, e); break; // Q键触发平方按钮
                case Key.R: butquarter_Click(sender, e); break; // R键触发四分之一按钮
                case Key.B: btnbur_Click(sender, e); break; // B键触发某个特定功能
                case Key.OemPeriod: btnDot_Click(sender, e); break; // 小数点键
                case Key.Back: btnremove_Click(sender, e); break; // Backspace键触发删除功能
                case Key.D: btnCE_Click(sender, e); break; // D键触发清除当前输入
                case Key.Escape: btnC_Click(sender, e); break; // Esc键触发全部清除
                case Key.OemPlus:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift) // Shift+加号键
                        btnAdd_Click(sender, e); // 触发加法按钮
                    else
                        btnEqual_Click(sender, e); // 否则，触发等于按钮
                    break;
                case Key.OemMinus: btnSub_Click(sender, e); break; // 减号键
                case Key.OemQuestion: btnDiv_Click(sender, e); break; // 斜杠键，通常代表除法
                                                                      // Ctrl+V粘贴操作
                case Key.V:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Control)
                    {
                        try
                        {
                            label = Clipboard.GetText(TextDataFormat.Text); // 从剪贴板获取文本
                            double.Parse(label); // 尝试将文本转换为double类型，检查是否为有效数字
                        }
                        catch
                        {
                            maintext.Text = "无效输入"; // 如果转换失败，显示错误信息
                            break;
                        }
                        maintext.Text = Clipboard.GetText(TextDataFormat.Text); // 显示粘贴的内容
                    }
                    break;
                // Ctrl+C复制操作
                case Key.C:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Control)
                        Clipboard.SetText(maintext.Text); // 复制计算结果到剪贴板
                    break;
                // Ctrl+X剪切操作
                case Key.X:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Control)
                    {
                        Clipboard.SetText(maintext.Text); // 将计算结果显示内容复制到剪贴板
                        maintext.Text = "0"; // 清空显示区域
                    }
                    break;
            }
        }
        private void animation(Border p, ThicknessAnimation marginAnimation, ColorAnimation colorAnimation)
        {
            // 创建动画以平滑改变面板的Margin属性和背景色
            var sb = new Storyboard();

            Storyboard.SetTarget(marginAnimation, p); // 设置动画作用的对象为"panel"
            Storyboard.SetTargetProperty(marginAnimation, new PropertyPath(FrameworkElement.MarginProperty)); // 设置动画影响的属性为Margin

            Storyboard.SetTarget(colorAnimation, p); // 设置动画目标为"panel"
            Storyboard.SetTargetProperty(colorAnimation, new PropertyPath("(Border.Background).(SolidColorBrush.Color)")); // 动画作用于背景色

            // 将两个动画加入到Storyboard中
            sb.Children.Add(marginAnimation);
            sb.Children.Add(colorAnimation);

            // 开始执行Storyboard中的动画
            sb.Begin();
        }


        //下滑栏
        // 当记录按钮(record)被点击时的处理
        private void record_Click(object sender, RoutedEventArgs e)
        {
            // 更改标题栏背景色为深色
            Title.Background = new SolidColorBrush(Color.FromArgb(0x45, 0x00, 0x00, 0x00));

            // 显示用于展示进制转换的面板
            belowdarkpanel.Visibility = Visibility.Visible;

            // 将主显示区的十进制数转换为其他进制并分别显示
            HEX.Text = Convert.ToString((int)double.Parse(maintext.Text), 16); // 十进制转十六进制
            DEC.Text = double.Parse(maintext.Text) + ""; // 十进制直接显示
            OCT.Text = Convert.ToString((int)double.Parse(maintext.Text), 8); // 十进制转八进制
            BIN.Text = Convert.ToString((int)double.Parse(maintext.Text), 2); // 十进制转二进制

            belowpanel.Margin = new Thickness(0, this.Height, 0, 0);
            // Margin动画设置
            var marginAnimation = new ThicknessAnimation
            {
                From = new Thickness(0, this.Height, 0, 0),//起始位置
                To = new Thickness(0, 137, 0, 0), // 目标Margin值
                Duration = TimeSpan.FromSeconds(storytime), // 动画持续时间
                EasingFunction = new QuadraticEase() // 使用二次缓动效果
            };
            // 背景色动画设置
            var colorAnimation = new ColorAnimation
            {
                From = Color.FromArgb(0, 20, 20, 20), // 起始颜色
                To = Color.FromArgb(250, 46, 46, 46), // 结束颜色
                Duration = TimeSpan.FromSeconds(storytime),
                EasingFunction = new QuadraticEase()
            };
            animation(belowpanel, marginAnimation, colorAnimation);
        }
        // 当深色背景被鼠标按下时的处理
        private void belowdarkpanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // 恢复标题栏背景透明
            Title.Background = Brushes.Transparent;
            belowback();
        }

        private void belowback()
        {
            // 隐藏进制转换展示面板
            belowdarkpanel.Visibility = Visibility.Collapsed;

            // Margin动画设置，让面板回到初始位置
            var marginAnimation = new ThicknessAnimation
            {
                To = new Thickness(0, this.Height, 0, 0),
                Duration = TimeSpan.FromSeconds(storytime),
                EasingFunction = new QuadraticEase()
            };

            // 背景色动画设置，恢复原始颜色
            var colorAnimation = new ColorAnimation
            {
                To = Color.FromArgb(0, 20, 20, 20),
                Duration = TimeSpan.FromSeconds(storytime),
                EasingFunction = new QuadraticEase()
            };
            animation(belowpanel, marginAnimation, colorAnimation);
        }
        private void belowCollapsed()
        {
            // 恢复标题栏背景透明
            Title.Background = Brushes.Transparent;

            // 隐藏进制转换展示面板
            sidedarkpanel.Visibility = Visibility.Collapsed;

            // Margin动画设置，让下滑栏面板回到初始位置
            var marginAnimation = new ThicknessAnimation
            {
                To = new Thickness(0, 0, this.Width, 0),
                Duration = TimeSpan.FromSeconds(0),
                EasingFunction = new QuadraticEase()
            };

            // 背景色动画设置，恢复原始颜色
            var colorAnimation = new ColorAnimation
            {
                To = Color.FromArgb(0, 20, 20, 20),
                Duration = TimeSpan.FromSeconds(0),
                EasingFunction = new QuadraticEase()
            };
            animation(belowpanel, marginAnimation, colorAnimation);
        }



        //侧滑栏
        private void sideButton_Click(object sender, RoutedEventArgs e)
        {
            // 更改标题栏背景色为深色
            Title.Background = new SolidColorBrush(Color.FromArgb(0x45, 0x00, 0x00, 0x00));

            // 显示用于展示进制转换的面板
            sidedarkpanel.Visibility = Visibility.Visible;

            // Margin动画设置
            var marginAnimation = new ThicknessAnimation
            {
                To = new Thickness(0, 0, this.Width - 190, 0), // 目标Margin值
                Duration = TimeSpan.FromSeconds(storytime), // 动画持续时间
                EasingFunction = new QuadraticEase() // 使用二次缓动效果
            };
            // 背景色动画设置
            var colorAnimation = new ColorAnimation
            {
                From = Color.FromArgb(0, 20, 20, 20), // 起始颜色
                To = Color.FromArgb(250, 46, 46, 46), // 结束颜色
                Duration = TimeSpan.FromSeconds(storytime),
                EasingFunction = new QuadraticEase()
            };
            animation(sidepanel, marginAnimation, colorAnimation);
            belowback();
        }
        
        // 当深色面板(darkpanel)被鼠标按下时的处理
        private void cancelsideButton_Click(object sender, RoutedEventArgs e) { sideback(); }
        private void sidedarkpanel_MouseDown(object sender, MouseButtonEventArgs e) { sideback(); }
        private void sideback()
        {
            // 恢复标题栏背景透明
            Title.Background = Brushes.Transparent;

            // 隐藏进制转换展示面板
            sidedarkpanel.Visibility = Visibility.Collapsed;

            // Margin动画设置，让面板回到初始位置
            var marginAnimation = new ThicknessAnimation
            {
                To = new Thickness(0, 0, this.Width, 0),
                Duration = TimeSpan.FromSeconds(storytime),
                EasingFunction = new QuadraticEase()
            };

            // 背景色动画设置，恢复原始颜色
            var colorAnimation = new ColorAnimation
            {
                To = Color.FromArgb(0, 20, 20, 20),
                Duration = TimeSpan.FromSeconds(storytime),
                EasingFunction = new QuadraticEase()
            };
            animation(sidepanel, marginAnimation, colorAnimation);
        }

        private void SetButton_Clik(object sender, RoutedEventArgs e)
        {
        }

        private void sideCollapsed()
        {
            // 恢复标题栏背景透明
            Title.Background = Brushes.Transparent;

            // 隐藏进制转换展示面板
            sidedarkpanel.Visibility = Visibility.Collapsed;

            // Margin动画设置，让面板回到初始位置
            var marginAnimation = new ThicknessAnimation
            {
                To = new Thickness(0, 0, this.Width, 0),
                Duration = TimeSpan.FromSeconds(0),
                EasingFunction = new QuadraticEase()
            };

            // 背景色动画设置，恢复原始颜色
            var colorAnimation = new ColorAnimation
            {
                To = Color.FromArgb(0, 20, 20, 20),
                Duration = TimeSpan.FromSeconds(0),
                EasingFunction = new QuadraticEase()
            };
            animation(sidepanel, marginAnimation, colorAnimation);
        }
    }
}
