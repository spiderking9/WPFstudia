   M S B A M L   `   `   `  ����H  DUrlopyApiXaml, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:UrlopyApiXaml.Views.DodawanieUrlopyApiXaml.Views.Dodawanie  5      <    6UrlopyApiXaml.Views.Dodawanie.DodajFotorejestracjeView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =local+clr-namespace:UrlopyApiXaml.Views.Dodawanie     5      .��5	      �   � ColumnDefinitions  5
   
   �� 5      $	��150 �6   �� 5      $	��200 �6    � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��50 �6   .+�5   
   �� $��0��6   $��0��6   $��Godzina Wejscia��6-   $��0,8,0,8q�6G   $��Center=�6X   $
��Left=�6z   (  "System.Windows.Controls.DatePicker  5   
   $��0��6   $��1��6"   $��Center=�62      SelectedDate 6M   ��  �� Path$ FOT_GodzinaWejscia� �� UpdateSourceTrigger$ PropertyChanged=��� 5   
   $��1��6   $��0��6   $��Godzina Wyjscia��6-   $��0,8,0,8q�6G   $��Center=�6X   $
��Left=�6z     5   
   $��1��6   $��1��6"   $��Center=�62    6M   �� $ FOT_GodzinaWyjscia�$ PropertyChanged=��� 5   
   $��2��6   $��0��6   $��	Pracownik��6-   $��0,8,0,8q�6A   �� 5   
   $��2��5   !   $��1��5    !    �� DisplayMemberPath$ ImieNazwisko��5"   !    �� SelectedValuePath$ 	PRA_PraID��5#   !   $��Center=�5%   !   ��5!   !   �� *PracownicyComboBoxItems+ �� SelectedValue 5$   !   �� $ 	FOT_PraID� �� Mode$ TwoWay=�5%   !   �� 5'   
   $��3��6   $��0��6   $��Data Wejscia��6-   $��0,8,0,8q�6D   $��Center=�6U   $
��Left=�6w     5(   
   $��3��6   $��1��6"   $��Center=�62    6M   �� $ FOT_DataWejscia�$ 	LostFocus=�	 �� ValidatesOnDataErrors	 . �� 5)   
   $��4��6   $��0��6   $��Data Wyjscia��6-   $��0,8,0,8q�6D   $��Center=�6U   $
��Left=�6w     5*   
   $��4��6   $��1��6"   $��Center=�62    6M   �� $ FOT_DataWyjscia�$ 	LostFocus=�	 . �� 5,   
   $��6��6   $��20,4,0,0q�6   $��2��60   $��Edytuj Fotorejestracje��6D   
�������$��20(�6�   ��6x   �� *SaveCommand+6�   5-      5.      