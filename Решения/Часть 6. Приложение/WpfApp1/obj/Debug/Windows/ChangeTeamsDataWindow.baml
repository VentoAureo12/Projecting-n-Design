   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApp1.WindowsWpfApp1.Windows  5   	   +    %WpfApp1.Windows.ChangeTeamsDataWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:WpfApp1.Windows     5   	     � Title$7  1Изменить данные о командах��5   	   $	��450��6,   $	��800��69   .��5	      �  � RowDefinitions 5
   
   �� 5      $��1* �6   �� 5      $
��0.7* �6   �� 5      $��1* �6   �� 5      $	��10* �6   .+�5   
   o� $��0��6   .@�5      m� $��Управление��6   .@�5      m� -   5        $0��*Добавить новую команду��5      6;   m� 5      -   5        $ ��Редактировать��5      62   m� 5      -   5        $'��!Удалить выбранное��5      66   m� 5      -   5        $+��%Сохранить изменения��5      68   5      5      �� 5   
   -   5         ��Name$ SnapBackButton��5      $��1��6F   $
��Left=�6S   $��25��6n   $	��100��6z   .��6�   Главная форма6�   �� 5   
   $5��/Поиск по названию команды��6   $��25��65   $	��200��6A   $��1��6M   $��Center=�6Z    �� TextAlignment$ Center=�6w   6�   �� 5   
   -   5         ��Name$ SearchTextBox��5      $��25��6)   $	��200��65   $��2��6i   $��Center=�6v   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ TeamsDataGrid��5         AutoGenerateColumns .  $��3��6F      
IsReadOnly .    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Код команды��6%   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6:   �� *Код_команды+  5      $	 Наименование��6%   
 6;   �� *)'Наименование_команды+5!      5"      5#      