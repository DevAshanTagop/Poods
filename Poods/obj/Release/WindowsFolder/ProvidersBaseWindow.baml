   M S B A M L   `   `   `  ���� @  <Poods, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Poods.WindowsFolderPoods.WindowsFolder  -    'Poods.WindowsFolder.ProvidersBaseWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     3local!clr-namespace:Poods.WindowsFolder       � Title$X  RПанель управление базами данных поставшиков�� � WindowStartupLocation$ CenterScreen=�$	��400��$	��870��$	��870��$	��400��.��� .+�&   System.Windows.Controls.DataGrid  -   $��DataGridProvider��   AutoGenerateColumns .  $��10,10,10,122q�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$% Номер поставщика��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *
IdProvider+  $ Название��   Width5  /System.Windows.Controls.DataGridLengthConverter$ *  �� *ProviderName+  $# Контактное лицо�� �� *ContactPerson+  $ Телефон�� �� *Phone+  $' !Электронная почта�� �� *Email+  $ 
Адрес�� �� *	Address+�� -   $��Добавить��$��	10,0,0,10q�$��32��$��Bottom=�$
��Left=�$��93���� -   $��Обновить��$��
108,0,0,10q�$��32��$��Bottom=�$
��Left=�$��92���� -   $��NameTextBox��$��
130,0,0,55q� �� TextWrapping$
 Wrap=�$�� ��$��Bottom=�$
��Left=�$	��123��$��41���� -   $��ContactPersonTextBox��$��
258,0,0,55q�$
 Wrap=�$�� ��$��Bottom=�$
��Left=�$	��123��$��41���� -   $��PhoneTextBox��$��
385,0,0,55q�$
 Wrap=�$�� ��$
��Left=�$	��124��$��41��$��Bottom=��� -   $��EmailTextBox��$��
514,0,0,55q�$
 Wrap=�$�� ��$��Bottom=�$
��Left=�$	��125��$��41���� -   $��AddressTextBox��$��
644,0,0,55q�$
 Wrap=�$�� ��$��Bottom=�$
��Left=�$	��196��$��41���� $
��Left=�$��130,0,0,101q�$
��Wrap=�$��Название��$��Bottom=�$	��123���� $
��Left=�$��258,0,0,101q�$
��Wrap=�$#��Контактное лицо��$��Bottom=�$	��123���� $
��Left=�$��385,0,0,101q�$
��Wrap=�$!��Номер телефона��$	��124�� J� RenderTransformOrigin$ 
1.327,-1.5&�$��16��$��Bottom=��� $
��Left=�$��514,0,0,101q�$
��Wrap=�$'��!Электронная почта��$��Bottom=�$	��125���� $
��Left=�$��644,0,0,101q�$
��Wrap=�$��
Адрес��$	��196��$��16��$��Bottom=��� -	   $��Удалить��$
��Left=�$��
207,0,0,10q�$ 0.454,0.102&�$��92��$��32��$��Bottom=��� -
   $��ComboBoxIdProvider��$
��Left=�$��	10,0,0,55q�$	��115��$��41��$��Bottom=��� $
��Left=�$��
10,0,0,101q�$
��Wrap=�$%��Номер поставщика��$��Bottom=�$	��115��$ 
0.25,0.499&��� -   $/��)Перезагрузить таблицу��$
��Left=�$��
304,0,0,10q�$ 0.454,0.102&�$	��144��$��32��$��Bottom=�