SetActiveLib -work
comp -include "$dsn\src\task4.vhd" 
comp -include "$dsn\src\test-bench\task4\sum2_TB.vhd" 
asim +access +r TESTBENCH_FOR_sum2 

wave 
wave -noreg A
wave -noreg B
wave -noreg S_1
wave -noreg C_1
wave -noreg S_2
wave -noreg C_2
wave -noreg C 

wave -noreg error

run 320 ns
# The following lines can be used for timing simulation
# acom <backannotated_vhdl_file_name>
# comp -include "$dsn\src\test-bench\sum2_TB_tim_cfg.vhd" 
# asim +access +r TIMING_FOR_sum2 
