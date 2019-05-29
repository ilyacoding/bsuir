SetActiveLib -work
comp -include "$dsn\src\task 5.9\TFF.vhd" 
comp -include "$dsn\src\task 5.9\test-bench\tff_TB.vhd" 
asim +access +r tff_tb 
wave 
wave -noreg T
wave -noreg E
wave -noreg CLR
wave -noreg CLK
wave -noreg Q


run 1 us
