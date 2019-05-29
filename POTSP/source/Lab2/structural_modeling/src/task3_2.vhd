library ieee;
use ieee.std_logic_1164.all;
-- v. 1
entity task3_2 is
   port(        					
      X, Y, Z: in std_logic; 
      F: out std_logic
   ); 
end task3_2;

architecture struct of task3_2 is

component and3
	port(        					
		A, B, C: in std_logic; 
		R: out std_logic
	);	
end component;

component and2
	port(        					
		A, B: in std_logic; 
		R: out std_logic
	);	
end component;

component or2
	port(        					
		A, B: in std_logic; 
		R: out std_logic
	);	
end component;

component inv
	port(
		A: in std_logic;
		nA: out std_logic
	);
end component;

signal nX, nY, nZ, or_X_nY, and_or_X_nY_Z, and_nX_Y_nZ: std_logic;
begin						  
	U1: inv port map(X, nX);
	U2: inv port map(Y, nY);
	U3: inv port map(Z, nZ);
	U4: or2 port map(X, nY, or_X_nY);
	U5: and2 port map(or_X_nY, Z, and_or_X_nY_Z);
	U6: and3 port map(nX, y, nZ, and_nX_y_nZ);
	U7: or2 port map(and_or_X_nY_Z, and_nX_Y_nZ, F);
end struct;

architecture beh of task3_2 is
begin
	F <= ((X or not Y) and Z) or (not X and Y and not Z);
end beh;