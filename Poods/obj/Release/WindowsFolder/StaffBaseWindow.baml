   M S B A M L   `   `   `  ���� @  <Poods, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Poods.WindowsFolderPoods.WindowsFolder  )    #Poods.WindowsFolder.StaffBaseWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     3local!clr-namespace:Poods.WindowsFolder       � Title$X  RПанель управление базами данных сотрудников�� � WindowStartupLocation$ CenterScreen=�$	��450��$
��1000��$
��1000��$	��450��.��� .+�&   System.Windows.Controls.DataGrid  -     Name$ DataGridStaff��   AutoGenerateColumns .  $��10,10,10,146q�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Номер клиента��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *	IdStaff+  $ Фамилия��   Width5  /System.Windows.Controls.DataGridLengthConverter$ 90  �� *
LastName+  $ Имя��$ 90  �� *	FirstName+  $ Отчество��$ 90  �� *MiddlуName+  $ Должность�� �� *
Position+  $ Номер смены�� �� *ShiftNumber+  $ Дата найма�� �� *
HireDate+  $ Зарплата��$ 90  �� *Salary+  $ 
Логин��$ *  �� *Login+  $ Пароль��$ *  �� *
Password+  $! Статус акаунта��$ 90  �� *StatusOfAccount+  $, &Последняя дата входа�� �� *LastDateOfAuthorization+�� -   $��Добавить��$��	10,0,0,10q�$��41��$��Bottom=�$
��Left=�$��84���� -   $��Обновить��$��	99,0,0,10q�$��41��$��Bottom=�$
��Left=�$��92���� -   $��LastNameTextBox��$��	99,0,0,63q� �� TextWrapping$
 Wrap=�$�� ��$��Bottom=�$
��Left=�$��92��$��41���� -   $��FirstNameTextBox��$��
196,0,0,63q�$
 Wrap=�$�� ��$��Bottom=�$
��Left=�$��92��$��41���� -   $��MiddlуNameTextBox��$��
293,0,0,63q�$
 Wrap=�$�� ��$��Bottom=�$
��Left=�$��93��$��41���� -   $��LoginTextBox��$��
683,0,0,63q�$
 Wrap=�$�� ��$��Bottom=�$
��Left=�$��92��$��41���� -   $��PasswordTextBox��$��
780,0,0,63q�$
 Wrap=�$�� ��$��Bottom=�$
��Left=�$��92��$��41���� $
��Left=�$��
99,0,0,109q�$
��Wrap=�$��Фамилия��$��Bottom=�$��92���� $
��Left=�$��196,0,0,109q�$
��Wrap=�$��Имя��$��Bottom=�$��92���� $
��Left=�$��293,0,0,109q�$
��Wrap=�$��Отчество��$��93��$��16��$��Bottom=�	 J� RenderTransformOrigin$	 
1.327,-1.5&��� $
��Left=�$��391,0,0,109q�$
��Wrap=�$��Bottom=�$��93��$��Должность���� $
��Left=�$��683,0,0,109q�$
��Wrap=�$��
Логин��$��92��$��16��$��Bottom=��� $
��Left=�$��780,0,0,109q�$
��Wrap=�$��Пароль��$��92��$��16��$��Bottom=��� -	   $��Удалить��$
��Left=�$��
196,0,0,10q�$	 0.454,0.102&�$��92��$��41��$��Bottom=��� -
   $��ComboBoxIdStaff��$
��Left=�$��	10,0,0,63q�$��84��$��41��$��Bottom=��� $
��Left=�$��
10,0,0,109q�$
��Wrap=�$%��Номер сотрудника��$��Bottom=�$��84��$	 0.282,0.624&��� -   $��ComboBoxPosition��$
��Left=�$��
391,0,0,63q�$��93��$��41��$��Bottom=��� -   $��ComboBoxStatusOfAccount��$
��Left=�$��
877,0,0,63q�$��93��$��41��$��Bottom=��� $
��Left=�$��878,0,0,109q�$
��Wrap=�$��92��$��16��$��Bottom=�$"��Cтатус аккаунта���� -   
 ��Name$
 SalaryTextBox��$��
586,0,0,63q�$
 Wrap=�$�� ��$��Bottom=�$
��Left=�$��92��$��41���� $
��Left=�$��586,0,0,109q�$
��Wrap=�$��92��$��16��$��Bottom=�$��Зарпалата���� -   $/��)Перезагрузить таблицу��$
��Left=�$��
293,0,0,10q�$	 0.454,0.102&�$	��145��$��41��$��Bottom=��� -   $
 ShiftNumberTextBox��$��
489,0,0,63q�$
 Wrap=�$�� ��$��Bottom=�$
��Left=�$��92��$��41���� $
��Left=�$��489,0,0,109q�$
��Wrap=�$��92��$��16��$��Bottom=�$��Номер смены��