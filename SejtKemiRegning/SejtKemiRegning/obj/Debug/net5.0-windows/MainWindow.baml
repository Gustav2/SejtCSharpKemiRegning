   M S B A M L   `   `   `  ����  SejtKemiRegning     SejtKemiRegning.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Icon$  	/icon.ico��5   	    � Title$ Molarmasse beregner��5   	   $	��450��6%   $	��800��62    � 
ResizeMode$ NoResize=�6>   .��5	      � $	��432��6   ��5
   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ 	#FFEF473A��6    � Offset$ 1Q�61   � 5      $ 	#FFCB2D3E��6   5      .+�5   
   �� -   5        $��Udregn��5      $
��Left=�6"   $��59��6=   $��150,299,0,0q�6I   $	��Top=�6^   $	��200��6v    � Cursor$
 Hand��6�   $��Bahnschrift SemiBold)�6�   $��18(�6�   ���	#FF2063A8
���������6�   Z� 6  �� 5   
   -   5        $��Eksportér til Excel��5      $
��Left=�6/   $��59��6J   $��450,299,0,0q�6V   $	��Top=�6k   $	��200��6�   $
 Hand��6�   $��Bahnschrift SemiBold)�6�   $��18(�6�   ���	#FF2063A8
���������6�   Z� 6  �� 5   
   -   5        $��
InputField��5      $��Center=�6$   $��50��6A   $��	0,124,0,0q�6M    �� TextWrapping$
 Wrap=�6`   $	��Top=�6t   $	��500��6�   $��Bahnschrift)�6�   $��16(�6�   	 �� TextAlignment$	 Center=�6�   $��Center=�6�   $��Center=�6�   
 � UseLayoutRounding$
 False��6  �� 5   
   -   5        $��OutputField��5      $��Center=�6%   $��	0,203,0,0q�6B   $4��.Her kommer summen af molarmasserne til at stå��6U   $
 Wrap=�6�   $	��Top=�6�   $	��500��6�   $��50��6�   $��16(�6�   $��Bahnschrift)�6�   
���   �
�������$	 Center=�6j  $��Center=�6�  $��Center=�6�   �� SelectionOpacity$ 1Q�6�  ${�False��6�   �� SelectionTextBrush 6�   Z�  �� SelectionBrush 6  Z� ��6@  Z� .��6�  ��5      �� 5      .��5      5      �� 5   
    J� IsHitTestVisible$ False��6   $��Indtast atomer��6-   $	��Top=�6C   $��Center=�6[   $��	0,138,0,0q�6x   
�������$��Bahnschrift)�6�   $��18(�6�   ��5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � y� �� Value$ 	Collapsed=�63    �� Triggers 5      �� 5       �� Binding 6&   �� *Text+ �� ElementName$ 
InputField�� �� Value  6W   .a�5      ��  � y�$ Visible=�6;   5       5"      5$      �� 5%   
   $��Molarmasse beregner��6   $��Center=�6.   $��0,20,0,0q�6K   $	��Top=�6]   $	��800��6u   $��48(�6�   $��80��6�   $��Center=�6�   $��Center=�6�   $��Bahnschrift)�6�   
�������6�   �� 5&   
   -   5         ��Name$ succes��5&      $��Eksporterede til Excel ��6    $
��Left=�6B   $��462,363,0,0q�6]   $	��Top=�6r   $	��176��6�   $��Bahnschrift)�6�   $��16(�6�   ���	#FF00F121$y�Hidden=�6�   5(      5*      5+      