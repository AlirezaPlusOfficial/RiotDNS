   M S B A M L   `   `   `  ���� B  >RiotDNS, Version=2.0.2.6, Culture=neutral, PublicKeyToken=null!clr-namespace:RiotDNSRiotDNS      RiotDNS.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     'localclr-namespace:RiotDNS       � Title$  RiotDNS��$	��500��$	��350�� � WindowStartupLocation$ CenterScreen=� � WindowStyle$
 None=� � AllowsTransparency . 
������ .��� .+��� ���#2A2C2D �� CornerRadius$ 30�����#EFEFEF$��10q�._��� -    ��Name$ dnsCombo��$��0,82,0,0q� J� RenderTransformOrigin$ 0.502,0.577&�$��Center=�$	��Top=�$	��178���� ���#EFEFEF$��40��$	��220��$��Center=�$	��Top=�$ 	0,0,12,12��._��� $��R I O T   D N S�����#2A2C2D$��18(�$��Fonts/#Kanit Medium)�$��Center=�$��Center=�$��0,5,0,0q��� ���#EFEFEF$��20��$	��190��$��Center=�$��Bottom=�$��0,0,0,7q�$ 5,5,0,0��._��� -    ��Name$ tagLbl��$ ��CHOOSE   SET   WE'RE READY�����#2A2C2D$��11(�$��Fonts/#Kanit Medium)�$��Center=�$��Center=�A� -    A�Name$
 EG_1��$	��100��$	��100�����#A9C220$��Center=�$��Center=�A� -   $
 EG_2��$	��100��$	��100�����#A9C220$��Center=�$��Center=�A� -   $
 EG_3��$	��100��$	��100�����#A9C220$��Center=�$��Center=�A� -   $
 ER_1��$	��100��$	��100�����#FF5231$��Center=�$��Center=�A� -   $
 ER_2��$	��100��$	��100�����#FF5231$��Center=�$��Center=�A� -   $
 ER_3��$	��100��$	��100�����#FF5231$��Center=�$��Center=�d� -	   	 d�Name$	 Tg_btn��$	��110��$	��110��$��Center=�$��Center=�   
TgBtnStyle#��[  
 � Triggers
 :�  :� RoutedEvent$ ToggleButton.Checked��[��� -
    ��Name$ Ellipse_Activated��.���� .��W�  g� 	BeginTime$ 00:00:00X� g� Duration$ 00:00:03D� W� From$	 100X�	 W� To$	 300X� �� TargetProperty$ (Ellipse.Width)� �� 
TargetName$
 EG_1�� g� RepeatBehavior$ Forever��W� $ 00:00:00X�$ 00:00:03D�$	 100X�$	 300X�$ (Ellipse.Height)�$
 EG_1��$ Forever��W� $ Opacity�$
 EG_1��$	 1.0X�$	 0.0X�$ 00:00:00X�$ 00:00:03D�$ Forever��W� $ 00:00:01X�$ 00:00:03D�$	 100X�$	 300X�$ (Ellipse.Width)�$
 EG_2��$ Forever��W� $ 00:00:01X�$ 00:00:03D�$	 100X�$	 300X�$ (Ellipse.Height)�$
 EG_2��$ Forever��W� $ Opacity�$
 EG_2��$	 1.0X�$	 0.0X�$ 00:00:01X�$ 00:00:03D�$ Forever��W� $ 00:00:02X�$ 00:00:03D�$	 100X�$	 300X�$ (Ellipse.Width)�$
 EG_3��$ Forever��W� $ 00:00:02X�$ 00:00:03D�$	 100X�$	 300X�$ (Ellipse.Height)�$
 EG_3��$ Forever��W� $ Opacity�$
 EG_3��$	 1.0X�$	 0.0X�$ 00:00:02X�$ 00:00:03D�$ Forever��:� $ ToggleButton.Unchecked��[���  �� BeginStoryboardName$ Ellipse_Activated���� -   $ Ellipse_Deactivated��.���� .��W� $ 00:00:00X�$ 00:00:03D�$	 300X�$	 100X�$ (Ellipse.Width)�$
 ER_1��W� $ 00:00:00X�$ 00:00:03D�$	 300X�$	 100X�$ (Ellipse.Height)�$
 ER_1��W� $ Opacity�$
 ER_1��$	 0.0X�$	 1.0X�$ 00:00:00X�$ 00:00:03D�W� $ 00:00:00X�$ 00:00:02D�$	 250X�$	 100X�$ (Ellipse.Width)�$
 ER_2��W� $ 00:00:00X�$ 00:00:02D�$	 250X�$	 100X�$ (Ellipse.Height)�$
 ER_2��W� $ Opacity�$
 ER_2��$	 0.0X�$	 1.0X�$ 00:00:00X�$ 00:00:02D�W� $ 00:00:00X�$ 00:00:01D�$	 200X�$	 100X�$ (Ellipse.Width)�$
 ER_3��W� $ 00:00:00X�$ 00:00:01D�$	 200X�$	 100X�$ (Ellipse.Height)�$
 ER_3��W� $ Opacity�$
 ER_3��$	 0.0X�$	 1.0X�$ 00:00:00X�$ 00:00:01D��� -    ��Name$ 	Close_App��  CloseAppStyle#��[ 