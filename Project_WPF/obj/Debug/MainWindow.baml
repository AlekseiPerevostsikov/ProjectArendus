   M S B A M L   `   `   `  ����F  BProject_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Project_WPFProject_WPF  5   	       Project_WPF.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Project_WPF     5   	     � Title$  
MainWindow��5   	   $��333.03��6   $	��385��6,    � WindowStartupLocation$ CenterScreen=�68    � 
ResizeMode$ CanMinimize=�6]   .��5	      �  � RowDefinitions 5
   
   �� 5      $	��79* �6   �� 5      $
��225* �6   .+�5   
   �� -   5         ��Name$ btnLogIn��5      $��Log in��6#   $
��Left=�64   $��131,134.333,0,0q�6O   $	��Top=�6h   $	��110��6�    �� 	IsDefault . $��29��6�   $��1��6�   �� 5   
   $��Login:��6   $
��Left=�6!   $��86,17.333,0,0q�6<   $	��Top=�6S   $��1��6k   �� 5   
   $��	Password:��6   $
��Left=�6$   $��86,73.333,0,0q�6?   $	��Top=�6V   $��1��6n   �� 5   
   $��2��6U    +� FocusedElement 6   ��  �� ElementName$ txtUserName��.+�5      �� -   5         ��Name$ txtUserName��5      $
��Left=�6+   $��24��6F   $��
166,98,0,0q�6R   	 �� TextWrapping$
	 Wrap=�6f   $	��Top=�6z   $	��120��6�   5      G� 5   
   -   5        
 G�Name$
 txtPassword��5      $
��Left=�6+   $��166,75.333,0,0q�6F   $	��Top=�6^   $��24��6v   $	��120��6�   $��1��6�   �� 5   
   $��WELCOME��6   $
��Left=�6"   $��	86,17,0,0q�6=   $	��Top=�6P   $��52��6h   $	��200��6t   $��36(�6�   5      5      