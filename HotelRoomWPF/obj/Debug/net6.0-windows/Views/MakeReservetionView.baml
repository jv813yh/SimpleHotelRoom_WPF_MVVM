   M S B A M L   `   `   `  ����G  CHotelRoomWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:HotelRoomWPF.ViewsHotelRoomWPF.Views  5      ,    &HotelRoomWPF.Views.MakeReservetionView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:HotelRoomWPF.Views     5      .��5      �   � IsSharedSizeScope$
  True��5   	    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� $��Make Reservation��5       
  Header#��[  5      � 5   
   $��1��5      $��0 25 0 0q�5       5       �� 5!      $
��auto �6    �� 5"      $
��auto �6    .+�5%      �� $
��Name��5&      $��0��5'      �� 5(      $��1��5)      $��0 5 0 0q�5*      ��5+      �� *
UserName+ �� UpdateSourceTrigger$ PropertyChanged=�5,      � 5/   
   $��2��50      $��0 10 0 0q�51       52      �� 53      $
��auto �6    �� 54      $
��auto �6     � ColumnDefinitions 56      �� 57      $
��auto �6#    z� SharedSizeGroup$ firstColumn��60   �� 58      $
��auto �6#   $ secondColumn��60   .+�5<      �� $��	Floor No.��5=      �� 5>      $��1��5?      $��0��5@      $��0 5 0 0q�5A      ��5B      �� *FloorNumber+$ PropertyChanged=��� 5E      $��10 0 0 0q�5F      $��Room No.��5G      $��1��5H      �� 5I      $��1��5J      $��1��5K      $��10 5 0 0q�5L      ��5M      �� *
RoomNumber+$ PropertyChanged=�5N      � 5Q   
   $��3��5R      $��0 10 0 0q�5S       5T      �� 5U      $
��auto �6    �� 5V      $
��auto �6     5X      �� 5Y      $
��auto �6#   $ firstColumn��60   �� 5Z      $
��auto �6#   $ secondColumn��60   .+�5^      �� $��
Start Date��5_      (  "System.Windows.Controls.DatePicker  5`      $��1��5a      $��0��5b      $��0 5 0 0q�5c         SelectedDate 5d      �� *	StartTime+$ PropertyChanged=��� 5g      $��10 0 0 0q�5h      $��End Date��5i      $��1��5j        5k      $��1��5l      $��1��5m      $��10 5 0 0q�5n       5o      �� *	EndTime+$ PropertyChanged=�5p      �� 5s   
   $��4��5t       �� Orientation$ 
Horizontal=�5u      $��0 20 0 0q�5v      .+�5w      �� $��Submit��5x      ��5y      �� *SubmitCommand+�� 5z      $��Cancel��5{      $��10 0 0 0q�5|      ��5}      �� *CancelCommand+5~      5      5�      