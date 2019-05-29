----------------------------------------------------------------------------------
-- Company: 
-- Engineer: 
-- 
-- Create Date:    17:29:11 11/11/2017 
-- Design Name: 
-- Module Name:    base_switch - Behavioral 
-- Project Name: 
-- Target Devices: 
-- Tool versions: 
-- Description: 
--
-- Dependencies: 
--
-- Revision: 
-- Revision 0.01 - File Created
-- Additional Comments: 
--
----------------------------------------------------------------------------------
library IEEE;
use IEEE.STD_LOGIC_1164.ALL;

-- Uncomment the following library declaration if using
-- arithmetic functions with Signed or Unsigned values
--use IEEE.NUMERIC_STD.ALL;

-- Uncomment the following library declaration if instantiating
-- any Xilinx primitives in this code.
--library UNISIM;
--use UNISIM.VComponents.all;

entity base_switch is
    Port(
	 i_SW : in  STD_LOGIC;
    i_RST : in  STD_LOGIC;
	 o_LED : out  STD_LOGIC
	 );
end base_switch;

architecture Behavioral of base_switch is
	signal led_status: STD_LOGIC := '0';
	signal sw_status: STD_LOGIC := '0';
begin
	process(i_RST, i_SW, led_status, sw_status)
	begin
		if i_RST = '1' then
			led_status <= '0';  
		elsif sw_status /= i_SW then	
			led_status <= not led_status;
			sw_status <= i_SW;
		end if;					
	end process;
	
	o_LED <= led_status;
end Behavioral;

