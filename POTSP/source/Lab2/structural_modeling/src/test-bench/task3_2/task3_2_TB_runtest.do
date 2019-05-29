SetActiveLib -work
comp -include "$dsn\src\task3_2.vhd" 
comp -include "$dsn\src\test-bench\task3_2\task3_2_TB.vhd" 
asim +access +r TESTBENCH_FOR_task3_2 

wave 

wave -noreg X
wave -noreg Y
wave -noreg Z

wave -noreg error

run 70 ns
# The following lines can be used for timing simulation
# acom <backannotated_vhdl_file_name>
# comp -include "$dsn\src\test-bench\task3_2_TB_tim_cfg.vhd" 
# asim +access +r TIMING_FOR_task3_2 
