library ieee;
use ieee.std_logic_1164.all;
 
entity mux2x2 is
   port(        					
      a, b, a1, b1, s: in std_logic; 
      z, z1: out std_logic
   ); 
end mux2x2;

architecture struct of mux2x2 is

component mux2 is
	port(
	a, b, s: in std_logic;
	z: out std_logic
	);
end component;
begin	
	MUX0: mux2 port map(a, b, s, z);
	MUX1: mux2 port map(a1, b1, s, z1);
end struct;