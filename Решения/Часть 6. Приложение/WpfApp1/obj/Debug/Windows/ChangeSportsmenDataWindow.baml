   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApp1.WindowsWpfApp1.Windows  5   	   /    )WpfApp1.Windows.ChangeSportsmenDataWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:WpfApp1.Windows     5   	     � Title$:  4Изменить данные спортсменов��5   	   $	��450��6-   $	��800��6:   .��5	      �  � RowDefinitions 5
   
   �� 5      $��1* �6   �� 5      $
��0.7* �6   �� 5      $��1* �6   �� 5      $	��10* �6   .+�5   
   o� $��0��6   .@�5      m� $��Управление��6   .@�5      m� -   5        $8��2Добавить нового спортсмена��5      6?   m� 5      -   5        $ ��Редактировать��5      62   m� 5      -   5        $��Удалить��5      6,   m� 5      -   5        $��Сохранить��5      6.   5      5      �� 5   
   -   5         ��Name$ SnapBackButton��5      $��1��6F   $��25��6S   $	��100��6_   $
��Left=�6k   .��6�   Главная форма6�   �� 5   
   $=��7Поиск по фамилии, или телефону��6   $��1��6:   $��25��6G   $	��200��6S    �� TextAlignment$ Center=�6_   $��Center=�6v   6�   �� 5   
   -   5         ��Name$ SearchTextBox��5      $��25��6)   $	��200��65   $��2��6i   $��Center=�6v   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ SportsmenDataGrid��5         AutoGenerateColumns .  $��3��6J      
IsReadOnly .    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$!	 Код спортсмена��6%   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6=   �� *Код_спортсмена+  5      $	 Имя��6%   
 62   �� *Имя+  5       $	 Фамилия��6%   
 66   �� *Фамилия+  5!      $	 Отчество��6%   
 67   �� *Отчество+4  .System.Windows.Controls.DataGridTemplateColumn  5"      $	 Дата рождения��6)      DateStartTemplate   CellTemplate# [  6@     EditingDateStartTemplate   CellEditingTemplate# [ 6r   6�     5#      $	 Телефон��6%   
 66   �� *Телефон+5%      5&      5'      