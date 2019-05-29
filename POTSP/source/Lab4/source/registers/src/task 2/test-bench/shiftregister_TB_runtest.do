SetActiveLib -work
comp -include "$dsn\src\task 2\ShiftRegister.vhd" 
comp -include "$dsn\src\task 2\test-bench\shiftregister_TB.vhd" 
asim +access +r shiftregister_TB 
wave 
wave -noreg Sin
wave -noreg SE
wave -noreg CLK
wave -noreg RST
wave -noreg -bin Dout_beh
wave -noreg -bin Dout_struct

run 1us
# The following lines can be used for timing simulation
# acom <backannotated_vhdl_file_name>
# comp -include "$dsn\src\TestBench\shiftregister_TB_tim_cfg.vhd" 
# asim +access +r TIMING_FOR_shiftregister 
