SetActiveLib -work
comp -include "$dsn\src\task 5.8\JKFF.vhd" 
comp -include "$dsn\src\task 5.8\test-bench\jkff_TB.vhd" 
asim +access +r jkff_tb 
wave 
wave -noreg J
wave -noreg K
wave -noreg CLK
wave -noreg Q


run 1 us
