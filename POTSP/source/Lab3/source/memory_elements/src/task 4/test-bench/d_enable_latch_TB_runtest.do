SetActiveLib -work
comp -include "$dsn\src\task 4\D_Enable_Latch.vhd" 	  
comp -include "$dsn\src\task 4\test-bench\d_enable_latch_TB.vhd" 
asim +access +r d_enable_latch_TB 
wave 
wave -noreg D
wave -noreg E
wave -noreg Q_struct
wave -noreg nQ_struct	
wave -noreg Q_beh
wave -noreg nQ_beh	 
wave -noreg Q2_struct
wave -noreg nQ2_struct	
wave -noreg Q2_beh
wave -noreg nQ2_beh

run 1 us
