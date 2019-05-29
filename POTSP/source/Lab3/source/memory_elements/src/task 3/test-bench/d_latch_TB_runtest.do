SetActiveLib -work
comp -include "$dsn\src\task 3\D_Latch.vhd" 	 
comp -include "$dsn\src\task 3\test-bench\d_latch_TB.vhd" 
asim +access +r d_latch_tb 
wave 
wave -noreg D

wave -noreg Q_struct
wave -noreg nQ_struct	
wave -noreg Q_beh
wave -noreg nQ_beh	 
wave -noreg Q_param
wave -noreg nQ_param 

run 1 us
