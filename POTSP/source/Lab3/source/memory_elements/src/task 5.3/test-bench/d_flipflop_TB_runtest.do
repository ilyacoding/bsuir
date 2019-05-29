SetActiveLib -work
comp -include "$dsn\src\task 5.3\D_FlipFlop.vhd" 
comp -include "$dsn\src\task 5.3\test-bench\d_flipflop_TB.vhd" 
asim +access +r d_flipflop_TB
wave 
wave -noreg D
wave -noreg CLK
wave -noreg Q

run 1 us
