   M S B A M L   `   `   `  ����  RentCalculation1    +RentCalculation.View.AccountantInvoicesPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5        N� Title$1  +Управление квитанциями��5      .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0,0,0,10q�6"   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��0,0,0,10q�62   .+�5      �� -   5         ��Name$ BuildingComboBox��5      $	��200��65   $��0,0,10,0q�6A   (  "System.Windows.Controls.DatePicker  5      -   5          Name$ StartDatePicker��5      $��0,0,10,0q�66     5      -   5        $ EndDatePicker��5      $��0,0,10,0q�64   �� 5      -   5         ��Name$ GenerateButton��5      $��Сформировать��61   6H   5      �� 5      -   5        $ ExportButton��5      $��Экспорт в Excel��6+   $��Right=�5      $	��150��61   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ InvoicesDataGrid��5       $��1��6      AutoGenerateColumns .     
IsReadOnly . 	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Здание��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 200 6[   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *Buildings.Address+6[     5      $
 Квартира��6%   $	 100 6Y    67   �� *Apartments.Id+6Y     5      $
 Период��6%   $	 100 6n    65   �� *PeriodStart+ �� StringFormat$ 
dd.MM.yyyy��6n     5      $
 
Сумма��6%   $	 100 6e    64   �� *TotalAmound+$ N2��6e     5      $
 Дата создания��6%   $	 100 6s    6<   �� *	CreatedAt+$ 
dd.MM.yyyy��6s   4  .System.Windows.Controls.DataGridTemplateColumn  5      $
 Действия��6)   $	 100 6;      CellTemplate 5      �� 5      .R�5       �� -   5        $��Просмотр��5    %   
 � Tag 6Q   �� *Id+5!      5#      5%      5&      5'      