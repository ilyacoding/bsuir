SetActiveLib -work
comp -include "$dsn\src\task3_1.vhd" 
comp -include "$dsn\src\test-bench\task3_1\task3_1_TB.vhd" 
asim +access +r TESTBENCH_FOR_task3_1 

wave 

wave -noreg G_L
wave -noreg A
wave -noreg B

wave -noreg error

run 160 ns
# The following lines can be used for timing simulation
# acom <backannotated_vhdl_file_name>
# comp -include "$dsn\src\test-bench\task3_1_TB_tim_cfg.vhd" 
# asim +access +r TIMING_FOR_task3_1 
