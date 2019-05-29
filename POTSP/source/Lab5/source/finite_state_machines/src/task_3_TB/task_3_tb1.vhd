-------------------------------------------------------------------------------
--
-- Title       : Task 3
-- Design      : 
-- Author      : User
-- Company     : Home
--
-------------------------------------------------------------------------------
--
-- File        : D:\Programming\VHDL\finite-state-machines\source\finite_state_machines\src\task_3_TB\task_3_tb1.vhd
-- Generated   : 10/28/17 14:56:57
-- From        : D:\Programming\VHDL\finite-state-machines\source\finite_state_machines\src\task 3\task_3.asf
-- By          : ASFTEST ver. v.2.1.3 build 56, August 25, 2005
--
-------------------------------------------------------------------------------
--
-- Description : 
--
-------------------------------------------------------------------------------

library IEEE;
use IEEE.std_logic_1164.all;
use IEEE.std_logic_arith.all;
use IEEE.std_logic_unsigned.all;


library IEEE;
use IEEE.STD_LOGIC_TEXTIO.all;
use STD.TEXTIO.all;

entity task_3_ent_tb1 is
end entity task_3_ent_tb1;

architecture task_3_arch_tb1 of task_3_ent_tb1 is
  constant delay_wr_in : Time := 5 ns;
  constant delay_pos_edge : Time := 5 ns;
  constant delay_wr_out : Time := 5 ns;
  constant delay_neg_edge : Time := 5 ns;

  file RESULTS : Text open WRITE_MODE is "results.txt";

  procedure WRITE_RESULTS(
    constant  CLK : in Std_logic;
    constant  RST : in Std_logic;
    constant  IP : in Std_logic_Vector (3 downto 0);
    constant  OP : in Std_logic_Vector (1 downto 0)
 ) is
     variable l_out : Line;
  begin
     WRITE(l_out, now, right, 15, ps);
     -- write input signals
     WRITE(l_out, CLK, right, 8);
     WRITE(l_out, RST, right, 8);
     WRITE(l_out, IP, right, 11);
     -- write output signals
     WRITE(l_out, OP, right, 9);
     WRITELINE(RESULTS, l_out);
  end;

  component task_3 is
    port(
      CLK : in Std_logic;
      RST : in Std_logic;
      IP : in Std_logic_Vector (3 downto 0);
      OP :out Std_logic_Vector (1 downto 0));
  end component; -- task_3;

 signal CLK : Std_logic;
 signal RST : Std_logic;
 signal IP : Std_logic_Vector (3 downto 0);
 signal OP : Std_logic_Vector (1 downto 0);

 signal cycle_num : Integer; -- takt number

-- this signal is added for compare test simulation results only
type test_state_type is (S0, S1, S2, S3, any_state);
signal  test_state : test_state_type;


begin
   UUT : task_3
   port map(
    CLK => CLK,
    RST => RST,
    IP => IP,
    OP => OP);

 STIMULI : process
 begin
 --  Test for all states of finite state machine

   CLK <= '0';   
   cycle_num <= 0;           
   wait for delay_wr_in;
   RST <= '1';
   IP <= "0000";
   test_state <= S0;

   wait for delay_pos_edge;
   CLK <= '1';
   wait for delay_wr_out;
   wait for delay_neg_edge; -- S0

   CLK <= '0';   
   cycle_num <= 1;           
   wait for delay_wr_in;
   RST <= '0';
   IP <= "0001";

   wait for delay_pos_edge;
   test_state <= S1;
   CLK <= '1';
   wait for delay_wr_out;
   wait for delay_neg_edge; -- S1

   CLK <= '0';   
   cycle_num <= 2;           
   wait for delay_wr_in;
   RST <= '0';
   IP <= "0010";

   wait for delay_pos_edge;
   test_state <= S2;
   CLK <= '1';
   wait for delay_wr_out;
   wait for delay_neg_edge; -- S2

   CLK <= '0';   
   cycle_num <= 3;           
   wait for delay_wr_in;
   RST <= '0';
   IP <= "0100";

   wait for delay_pos_edge;
   test_state <= S3;
   CLK <= '1';
   wait for delay_wr_out;
   wait for delay_neg_edge; -- S3


 -- Test length 4
  wait;      -- stop simulation
 end process; -- STIMULI;

 WRITE_RESULTS(CLK,RST,IP,OP);

end architecture task_3_arch_tb1;

configuration task_3_cfg_tb1 of task_3_ent_tb1 is
   for task_3_arch_tb1
      for UUT : task_3  use entity work.task_3(beh);
      end for;
   end for;
end task_3_cfg_tb1;
