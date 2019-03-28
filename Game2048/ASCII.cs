using System;
using System.Collections.Generic;
using System.Text;

namespace Game2048
{

	public enum ASCII : uint
	{
		UNKNOWN = 0,
		BORDER_CORNER_LEFT_UP = '┌',
		BORDER_CORNER_LEFT_DOWN = '└',
		BORDER_CORNER_RIGHT_UP = '┐',
		BORDER_CORNER_RIGHT_DOWN = '┘',
		BORDER_VERTICAL_LINE = '│',
		BORDER_HORIZONTAL_LINE = '─',
		BORDER2_CORNER_LEFT_UP = '╔',
		BORDER2_CORNER_LEFT_DOWN = '╚',
		BORDER2_CORNER_RIGHT_UP = '╗',
		BORDER2_CORNER_RIGHT_DOWN = '╝',
		BORDER2_VERTICAL_LINE = '║',
		BORDER2_HORIZONTAL_LINE = '═',
		FILL_SPACE = '█'
	}

}
