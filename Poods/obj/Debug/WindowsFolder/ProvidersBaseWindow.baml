   M S B A M L   `   `   `  ����@  <Poods, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Poods.WindowsFolderPoods.WindowsFolder  5   	   -    'Poods.WindowsFolder.ProvidersBaseWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:Poods.WindowsFolder     5   	     � Title$X  RПанель управление базами данных поставшиков��5       � WindowStartupLocation$ CenterScreen=�6E   $	��400��6j   $	��870��6w   $	��870��6�   $	��400��6�   .��5	      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��DataGridProvider��5         AutoGenerateColumns .  $��10,10,10,122q�6G      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$% Номер поставщика��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6?   �� *
IdProvider+  5      $ Название��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6X    67   �� *ProviderName+6X     5      $# Контактное лицо��6%    6>   �� *ContactPerson+  5      $ Телефон��6%    66   �� *Phone+  5      $' !Электронная почта��6%    6@   �� *Email+  5      $ 
Адрес��6%    64   �� *	Address+5      �� 5   
   -   5        $��Добавить��5      $��	10,0,0,10q�6F   $��32��6Y   $��Bottom=�6e   $
��Left=�6�   $��93��6�   �� 5   
   -   5        $��Обновить��5      $��
108,0,0,10q�6I   $��32��6]   $��Bottom=�6i   $
��Left=�6�   $��92��6�   �� 5   
   -   5        $��NameTextBox��5   &   $��
130,0,0,55q�6    �� TextWrapping$
 Wrap=�69   $�� ��6M   $��Bottom=�6U   $
��Left=�6p   $	��123��6�   $��41��6�   �� 5   
   -   5        $��ContactPersonTextBox��5   &   $��
258,0,0,55q�6   $
 Wrap=�6B   $�� ��6V   $��Bottom=�6^   $
��Left=�6y   $	��123��6�   $��41��6�   �� 5   
   -   5        $��PhoneTextBox��5   &   $��
385,0,0,55q�6   $
 Wrap=�6:   $�� ��6N   $
��Left=�6V   $	��124��6q   $��41��6}   $��Bottom=�6�   �� 5   
   -   5        $��EmailTextBox��5   &   $��
514,0,0,55q�6   $
 Wrap=�6:   $�� ��6N   $��Bottom=�6V   $
��Left=�6q   $	��125��6�   $��41��6�   �� 5   
   -   5        $��AddressTextBox��5   &   $��
644,0,0,55q�6   $
 Wrap=�6<   $�� ��6P   $��Bottom=�6X   $
��Left=�6s   $	��196��6�   $��41��6�   �� 5   
   $
��Left=�6   $��130,0,0,101q�6/   $
��Wrap=�6D   $��Название��6X   $��Bottom=�6h   $	��123��6�   �� 5   
   $
��Left=�6   $��258,0,0,101q�6/   $
��Wrap=�6D   $#��Контактное лицо��6X   $��Bottom=�6o   $	��123��6�   �� 5   
   $
��Left=�6   $��385,0,0,101q�6/   $
��Wrap=�6D   $!��Номер телефона��6X   $	��124��6n    J� RenderTransformOrigin$ 
1.327,-1.5&�6z   $��16��6�   $��Bottom=�6�   �� 5   
   $
��Left=�6   $��514,0,0,101q�6/   $
��Wrap=�6D   $'��!Электронная почта��6X   $��Bottom=�6q   $	��125��6�   �� 5    
   $
��Left=�6   $��644,0,0,101q�6/   $
��Wrap=�6D   $��
Адрес��6X   $	��196��6e   $��16��6q   $��Bottom=�6}   �� 5!   
   -	   5        $��Удалить��5!      $
��Left=�6G   $��
207,0,0,10q�6b   $ 0.454,0.102&�6v   $��92��6�   $��32��6�   $��Bottom=�6�   �� 5"   
   -
   5        $��ComboBoxIdProvider��5"   .   $
��Left=�6   $��	10,0,0,55q�6H   $	��115��6[   $��41��6g   $��Bottom=�6s   �� 5#   
   $
��Left=�6   $��
10,0,0,101q�6/   $
��Wrap=�6C   $%��Номер поставщика��6W   $��Bottom=�6o   $	��115��6�   $ 
0.25,0.499&�6�   �� 5$   
   -   5        $/��)Перезагрузить таблицу��5$      $
��Left=�6_   $��
304,0,0,10q�6z   $ 0.454,0.102&�6�   $	��144��6�   $��32��6�   $��Bottom=�6�   5%      5&      