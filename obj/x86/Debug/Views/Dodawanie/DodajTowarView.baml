   M S B A M L   `   `   `  ����H  DUrlopyApiXaml, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:UrlopyApiXaml.Views.DodawanieUrlopyApiXaml.Views.Dodawanie  5      2    ,UrlopyApiXaml.Views.Dodawanie.DodajTowarView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =local+clr-namespace:UrlopyApiXaml.Views.Dodawanie     5      .��5	      �   � ColumnDefinitions  5
   
   �� 5      $	��150 �6   �� 5      $	��200 �6    � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��80 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��50 �6   .+�5   
   �� $��0��6   $��0��6   $��Nazwa��6-   $��0,8,0,8q�6=   $��Center=�6N   $
��Left=�6p   �� 5   
   $��0��6   $��1��6   $��0,8,0,8q�6/   $	��169��6@   $
��Left=�6L   $��Center=�6�   $��Center=�6�   ��6g   �� *	TOW_Nazwa+ �� UpdateSourceTrigger$ 	LostFocus=� �� ValidatesOnDataErrors . 6�   �� 5   
   $��1��6   $��0��6   $	��Kod��6-   $��0,8,0,8q�6;   $��Center=�6L   $
��Left=�6n   �� 5   
   $��1��6   $��1��6   $��0,8,0,8q�6/   $	��169��6@   $
��Left=�6L   $��Center=�6�   $��Center=�6�   ��6g   �� *	TOW_Kod+$ 	LostFocus=� . 6�   �� 5   
   $��2��6   $��0��6   $
��Opis��6-   $��0,8,0,8q�6<   $��Center=�6M   $
��Left=�6o   �� 5   
   $��2��6   $��1��6   $��0,8,0,8q�6/   $	��169��6@   $
��Left=�6L   $	��Top=�5      $
��Left=�61    �� TextWrapping$
 Wrap=�6S   ��5   g   �� *
TOW_Opis+$ 	LostFocus=� . 5   S   �� 5   
   $��3��6   $��0��6   $��Kategoria Towarow��6-   $��0,8,0,8q�6I   �� 5    
   $��3��5!   !   $��1��5"   !    �� DisplayMemberPath$ 	KAT_Nazwa��5$   !    �� SelectedValuePath$ 	KAT_KatID��5%   !   $��Center=�5'   !   ��5#   !   �� *KategorieComboBoxItems+ �� SelectedValue 5&   !   ��  �� Path$ 	TOW_KatID�	 �� Mode$	 TwoWay=�5'   !   �� 5)   
   $��4��6   $��0��6   $��Stan ilościowy��6-   $��0,8,0,8q�6F   $��Center=�6W   $
��Left=�6y   �� 5*   
   $��4��6   $��1��6   $��0,8,0,8q�6/   $	��169��6@   $
��Left=�6L   $��Center=�6�   $��Center=�6�   ��6g   �� *TOW_StanIlosciowy+$ 	LostFocus=� . 6�   �� 5+   
   $��5��6   $��0��6   $��Zdjecie��6-   $��0,8,0,8q�6?   $��Center=�6P   $
��Left=�6r   �� 5,   
   $��5��6   $��1��6   $��0,8,0,8q�6/   $	��169��6@   $
��Left=�6L   $��Center=�6�   $��Center=�6�      errorTemplate
 =� ErrorTemplate#
 [  6  ��6g   �� *TOW_Zdjecie+$ 	LostFocus=� . 6  �� 5.   
   $��7��6   $��20,4,0,0q�6   $��2��60   $��Dodaj Towar��6D   
�������$��20(�6�   ��6m   �� *SaveCommand+6�   5/      50      