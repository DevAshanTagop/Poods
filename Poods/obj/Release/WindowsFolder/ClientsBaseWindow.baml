   M S B A M L   `   `   `  ���� @  <Poods, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Poods.WindowsFolderPoods.WindowsFolder  +    %Poods.WindowsFolder.ClientsBaseWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     3local!clr-namespace:Poods.WindowsFolder       � Title$R  LПанель управление базами данных клиентов�� � WindowStartupLocation$ CenterScreen=�$	��400��$	��850��$	��850��$	��400��.��� .+�&   System.Windows.Controls.DataGrid  -   $��DataGridClients��   AutoGenerateColumns .  $��10,10,10,122q�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Номер клиента��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *
IdClient+  $ Фамилия��   Width5  /System.Windows.Controls.DataGridLengthConverter$ 90  �� *
LastName+  $ Имя��$ 90  �� *	FirstName+  $ Отчество��$ 90  �� *MiddlуName+  $ 
Адрес��$ *  �� *	Address+  $! Номер телефона��$ *  �� *Phone+  $' !Электронная почта��$ *  �� *Email+  $% Дата регистрации�� �� *RegistrationDate+�� -   $��Добавить��$��	10,0,0,10q�$��32��$��Bottom=�$
��Left=�$��93���� -   $��Обновить��$��
108,0,0,10q�$��32��$��Bottom=�$
��Left=�$��92���� -   $��LastNameTextBox��$��
108,0,0,55q� �� TextWrapping$
 Wrap=�$�� ��$��Bottom=�$
��Left=�$��92��$��41���� -   $��FirstNameTextBox��$��
207,0,0,55q�$
 Wrap=�$�� ��$��Bottom=�$
��Left=�$��92��$��41���� -   $��MiddlуNameTextBox��$��
304,0,0,55q�$
 Wrap=�$�� ��$��Bottom=�$
��Left=�$��93��$��41���� -   $��AdressTextBox��$��
402,0,0,55q�$
 Wrap=�$�� ��$��Bottom=�$
��Left=�$��93��$��41���� -   $��PhoneNumberTextBox��$��
501,0,0,55q�$
 Wrap=�$�� ��$��Bottom=�$
��Left=�$	��153��$��41���� -	   $��EmailTextBox��$��
659,0,0,55q�$
 Wrap=�$�� ��$��Bottom=�$
��Left=�$	��171��$��41���� $
��Left=�$��108,0,0,101q�$
��Wrap=�$��Фамилия��$��Bottom=�$��92���� $
��Left=�$��207,0,0,101q�$
��Wrap=�$��Имя��$��Bottom=�$��92���� $
��Left=�$��304,0,0,101q�$
��Wrap=�$��Отчество��$��93��$��16��$��Bottom=� J� RenderTransformOrigin$ 
1.327,-1.5&��� $
��Left=�$��402,0,0,101q�$
��Wrap=�$��
Адрес��$��Bottom=�$��93���� $
��Left=�$��501,0,0,101q�$
��Wrap=�$!��Номер телефона��$	��153��$��16��$��Bottom=��� $
��Left=�$��659,0,0,101q�$
��Wrap=�$'��!Электронная почта��$	��171��$��16��$��Bottom=��� -
   $��Удалить��$
��Left=�$��
207,0,0,10q�$ 0.454,0.102&�$��92��$��32��$��Bottom=��� -   $��ComboBoxIdClient��$
��Left=�$��	10,0,0,55q�$��93��$��41��$��Bottom=��� $
��Left=�$��
10,0,0,101q�$
��Wrap=�$��Номер клиента��$��Bottom=�$��93��$ 
0.25,0.499&��� -   $/��)Перезагрузить таблицу��$
��Left=�$��
304,0,0,10q�$ 0.454,0.102&�$	��144��$��32��$��Bottom=�