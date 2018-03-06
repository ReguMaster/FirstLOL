#NoEnv
#KeyHistory 0
ListLines, Off

Status := 0

Start := true

Loop
{
	if ( Start = true )
	{
		if ( Status = 0 )
		{
			ImageSearch, FoundX, FoundY, 0, 0, A_ScreenWidth, A_ScreenHeight, *30 %A_WorkingDir%\img\gamefound.bmp

			if ( ErrorLevel = 0 )
			{
				Status := 1
			}
			
			Sleep, 100
		}
	}
}

return