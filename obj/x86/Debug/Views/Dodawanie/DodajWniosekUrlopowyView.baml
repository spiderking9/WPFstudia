   M S B A M L   `   `   `  ����H  DUrlopyApiXaml, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:UrlopyApiXaml.Views.DodawanieUrlopyApiXaml.Views.Dodawanie  5      <    6UrlopyApiXaml.Views.Dodawanie.DodajWniosekUrlopowyView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =local+clr-namespace:UrlopyApiXaml.Views.Dodawanie     5      .��5	      �   � ColumnDefinitions  5
   
   �� 5      $	��150 �6   �� 5      $	��200 �6    � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��50 �6   .+�5   
   �� $��0��6   $��0��6   $��Urlop od��6-   $��0,8,0,8q�6@   (  "System.Windows.Controls.DatePicker  5   
   $��0��6   $��1��6"   $��Center=�62      SelectedDate 6M   ��  �� Path$ 
WUR_DataOd� �� UpdateSourceTrigger$ 	LostFocus=� �� ValidatesOnDataErrors . �� 5   
   $��1��6   $��0��6   $��Urlop do��6-   $��0,8,0,8q�6@     5   
   $��1��6   $��1��6"   $��Center=�62    6M   �� $ 
WUR_DataDo�$ 	LostFocus=� . �� 5   
   $��2��6   $��0��6   $��Rodzaj urlopu��6-   $��0,8,0,8q�6E   �� 5   
   $��2��5   !   $��1��5   !    �� DisplayMemberPath$ 	RUR_Nazwa��5    !    �� SelectedValuePath$ 	RUR_RurID��5!   !   $��Center=�5#   !   ��5   !   �� *RodzajUrlopuComboBoxItems+ �� SelectedValue 5"   !   �� $ 	WUR_RurID�	 �� Mode$	 TwoWay=�$ 	LostFocus=� . 5#   !   �� 5%   
   $��3��6   $��0��6   $��	Pracownik��6-   $��0,8,0,8q�6A   �� 5&   
   $��3��5'   !   $��1��5(   !   $ PRA_Imie��5*   !   $ 	PRA_PraID��5+   !   $��Center=�5-   !   ��5)   !   �� *PracownikComboBoxItems+ 5,   !   �� $ 	WUR_PraID�$	 TwoWay=�$ 	LostFocus=� . 5-   !   �� 50   
   $��5��6   $��20,4,0,0q�6   $��2��60   $��Dodaj Wniosek Urlopowy��6D   
�������$��20(�6�   ��6x   �� *SaveCommand+6�   51      52      