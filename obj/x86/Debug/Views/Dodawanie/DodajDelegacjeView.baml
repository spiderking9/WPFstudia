   M S B A M L   `   `   `  ����H  DUrlopyApiXaml, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:UrlopyApiXaml.Views.DodawanieUrlopyApiXaml.Views.Dodawanie  5      6    0UrlopyApiXaml.Views.Dodawanie.DodajDelegacjeView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =local+clr-namespace:UrlopyApiXaml.Views.Dodawanie     5      .��5	      �   � ColumnDefinitions  5
   
   �� 5      $	��150 �6   �� 5      $	��200 �6    � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��80 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��50 �6   .+�5   
   �� $��0��6   $��0��6   $��	Pracownik��6-   $��0,8,0,8q�6A   �� 5   
   $��0��5   !   $��1��5   !    �� DisplayMemberPath$ ImieNazwisko��5    !    �� SelectedValuePath$ 	PRA_PraID��5!   !   $��Center=�5#   !   ��5   !   �� *PracownicyComboBoxItems+ �� SelectedValue 5"   !   ��  �� Path$ 	DEL_PraID� �� Mode$ TwoWay=�5#   !   �� 5&   
   $��1��6   $��0��6   $��Tytul��6-   $��0,8,0,8q�6=   $��Center=�6N   $
��Left=�6p   �� 5'   
   $��1��6   $��1��6   $��0,8,0,8q�6/   $	��169��6@   $
��Left=�6L   $��Center=�6�   $��Center=�6�   ��6g   �� *	DEL_Tytul+ �� UpdateSourceTrigger$ 	LostFocus=� �� ValidatesOnDataErrors . 6�   �� 5(   
   $��2��6   $��0��6   $��Rodzaj transportu��6-   $��0,8,0,8q�6I   $��Center=�6Z   $
��Left=�6|   �� 5)   
   $��2��6   $��1��6   $��0,8,0,8q�6/   $	��169��6@   $
��Left=�6L   $	��Top=�5*      $
��Left=�61   	 �� TextWrapping$
	 Wrap=�6S   ��5)   g   �� *DEL_JakiTransport+$ 	LostFocus=� . 5*   S   �� 5+   
   $��3��6   $��0��6   $��Miejscowosc Startu��6-   $��0,8,0,8q�6J   $��Center=�6[   $
��Left=�6}   �� 5,   
   $��3��6   $��1��6   $��0,8,0,8q�6/   $	��169��6@   $
��Left=�6L   $��Center=�6�   $��Center=�6�   ��6g   �� *DEL_MiejscowoscStartu+$ 	LostFocus=� . 6�   �� 5-   
   $��4��6   $��0��6   $��Miejscowosc Celu��6-   $��0,8,0,8q�6H   $��Center=�6Y   $
��Left=�6{   �� 5.   
   $��4��6   $��1��6   $��0,8,0,8q�6/   $	��169��6@   $
��Left=�6L   $��Center=�6�   $��Center=�6�   ��6g   �� *DEL_MiejscowoscCelu+$ 	LostFocus=� . 6�   �� 5/   
   $��5��6   $��0��6   $��Dzien Od��6-   $��0,8,0,8q�6@   $��Center=�6Q   $
��Left=�6s   (  "System.Windows.Controls.DatePicker  50   
   $��5��6   $��1��6"   $��Center=�62   
   SelectedDate
 6M   �� $ DEL_DzienOd�$ 	LostFocus=� . �� 51   
   $��6��6   $��0��6   $��Dzien Do��6-   $��0,8,0,8q�6@   $��Center=�6Q   $
��Left=�6s     52   
   $��6��6   $��1��6"   $��Center=�62   
 6M   �� $ DEL_DzienDo�$ 	LostFocus=� . �� 53   
   $��7��6   $��0��6   $��	Komentarz��6-   $��0,8,0,8q�6A   $��Center=�6R   $
��Left=�6t   �� 54   
   $��7��6   $��1��6   $��0,8,0,8q�6/   $	��169��6@   $
��Left=�6L   $��Center=�6�   $��Center=�6�   ��6g   �� *DEL_Komentarz+$ 	LostFocus=� . 6�   �� 56   
   $��9��6   $��20,4,0,0q�6   $��2��60   $��Dodaj Delegacje��6D   
�������$��20(�6�   ��6q   �� *SaveCommand+6�   57      58      