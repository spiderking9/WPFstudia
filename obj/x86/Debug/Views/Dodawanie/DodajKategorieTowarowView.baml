   M S B A M L   `   `   `  ����H  DUrlopyApiXaml, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:UrlopyApiXaml.Views.DodawanieUrlopyApiXaml.Views.Dodawanie  5      =    7UrlopyApiXaml.Views.Dodawanie.DodajKategorieTowarowView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =local+clr-namespace:UrlopyApiXaml.Views.Dodawanie     5      .��5	      �   � ColumnDefinitions  5
   
   �� 5      $	��150 �6   �� 5      $	��200 �6    � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $	��100 �6   �� 5      $��50 �6   �� 5      $��60 �6   .+�5   
   �� $��0��6   $��0��6   $��Nazwa��6-   $��0,8,0,8q�6=   $��Center=�6N   $��Center=�6p   �� 5   
   $��0��6   $��1��6   $��0,8,0,8q�6/   $	��169��6@   $
��Left=�6L   $��Center=�6�   $��Center=�6�   ��6g   �� *	KAT_Nazwa+ �� UpdateSourceTrigger$ 	LostFocus=� �� ValidatesOnDataErrors . 6�   �� 5   
   $��1��6   $��0��6   $
��Opis��6-   $��0,8,0,8q�6<   $��Center=�6M   $��Center=�6o   �� 5   
   $��1��6   $��1��6   $��0,8,0,8q�6/   $	��169��6@   $
��Left=�6L   $	��Top=�5      $
��Left=�61    �� TextWrapping$
 Wrap=�6S   ��5   g   �� *
KAT_Opis+$ 	LostFocus=� . 5   S   �� 5   
   $��4��6   $��20,4,0,0q�6   $��2��60   $��Dodaj Kategorie Towarow��6D   
�������$��20(�6�   ��6y   �� *SaveCommand+6�   5      5      