SetActiveLib -work
comp -include "$dsn\src\task 5.4-6\FDCPE.vhd" 
comp -include "$dsn\src\task 5.4-6\test-bench\FDCPE_TB.vhd" 
asim +access +r FDCPE_TB
wave 
wave -noreg CLR
wave -noreg PRE
wave -noreg D
wave -noreg E
wave -noreg CLK
wave -noreg Q 

run 2 us
