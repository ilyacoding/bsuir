SetActiveLib -work
comp -include "$dsn\src\task 1\asynchronous\AsynchronousRegister.vhd" 
comp -include "$dsn\src\task 1\asynchronous\test-bench\asynchronousregister_TB.vhd" 
asim +access +r asynchronousregister_tb
wave 
wave -noreg Din
wave -noreg EN
wave -noreg Dout_struct
wave -noreg Dout_beh

run 1us
# The following lines can be used for timing simulation
# acom <backannotated_vhdl_file_name>
# comp -include "$dsn\src\test-bench\asynchronousregister_TB_tim_cfg.vhd" 
# asim +access +r TIMING_FOR_asynchronousregister 
