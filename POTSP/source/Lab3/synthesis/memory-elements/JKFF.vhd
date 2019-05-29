library IEEE;
use IEEE.STD_LOGIC_1164.all;

entity JKFF is
	port(
		J : in STD_LOGIC;
		K : in STD_LOGIC;
		CLK : in STD_LOGIC;	
		Q : out STD_LOGIC
		);
end JKFF;

architecture beh of JKFF is
	signal q_t: STD_LOGIC;
begin
	process(J, K, CLK)
	begin
		if rising_edge(CLK) then 
			if (J = '1' and K = '1') then
				q_t <= not q_t;
			elsif K = '1' then
				q_t <= '0';
			elsif J = '1' then
				q_t <= '1';
			end if; 
		end if;
	end process; 
	
	Q <= q_t;
end beh;
