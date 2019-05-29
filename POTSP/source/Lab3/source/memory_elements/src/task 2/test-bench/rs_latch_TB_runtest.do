SetActiveLib -work					
comp -include "$dsn\src\task 2\RS_Latch.vhd"
comp -include "$dsn\src\Task 2\test-bench\rs_latch_TB.vhd" 
asim +access +r rs_latch_tb
wave 

wave -noreg R
wave -noreg S
wave -noreg Q_struct
wave -noreg nQ_struct	
wave -noreg Q_beh
wave -noreg nQ_beh	 
wave -noreg Q_param
wave -noreg nQ_param

run 1us
