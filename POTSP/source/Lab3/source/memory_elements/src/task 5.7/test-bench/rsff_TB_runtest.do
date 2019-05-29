SetActiveLib -work
comp -include "$dsn\src\task 5.7\RSFF.vhd" 
comp -include "$dsn\src\task 5.7\test-bench\rsff_TB.vhd" 
asim +access +r rsff_tb 
wave 
wave -noreg R
wave -noreg S
wave -noreg CLK
wave -noreg Q

run 1 us
