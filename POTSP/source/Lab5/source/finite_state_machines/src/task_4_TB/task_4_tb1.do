#  File: 'd:\Programming\VHDL\finite-state-machines\source\finite_state_machines\src\task_4_TB\task_4_tb1.do'
#  created: 10/28/17 15:08:20
#  from: 'd:\Programming\VHDL\finite-state-machines\source\finite_state_machines\src\task 4\task_4.asf'
#  by ASFTEST - v.2.1.3 build 56, August 25, 2005

#
# rebuild the project
#
comp "d:\Programming\VHDL\finite-state-machines\source\finite_state_machines\src\task 4\task_4.asf"
comp "d:\Programming\VHDL\finite-state-machines\source\finite_state_machines\src\task_4_TB\task_4_tb1.vhd"

#
# set top-level and initialize the simulator with Code Coverage Data
#
asim -cc -cc_dest $DSN/coverage/task_4_cc_tb1 -cc_hierarchy -cc_all task_4_cfg_tb1

#
# invoke Waveform Viewer window, add signals to Waveform
#
wave
wave -noreg -dec cycle_num
wave -noreg CLK
wave -noreg UUT/state
wave -noreg test_state
wave -noreg RST
wave -noreg IP
wave -noreg OP

#
#
#
run -all
endsim
write wave "d:\Programming\VHDL\finite-state-machines\source\finite_state_machines\src\task_4_TB\task_4_tb1.awf"
#close -wave
