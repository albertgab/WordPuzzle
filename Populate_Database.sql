INSERT INTO [Users]
           ([Username]
           ,[Password]
           )
     VALUES
	 		     ('Leonidas','Sparta123')
;

INSERT INTO [Users]
           ([Username]
           ,[Password]
           )
     VALUES
	 		     ('Boomer','qwe321')
;

INSERT INTO [Levels]
           ([Name]
           ,[Size]
           ,[Letters]
           )
     VALUES
	 		     ('Animals', 1010, 'JSDOIVBPOA' +
                                   'ASDGMONKEY' +
                                   'UXZYUIVTOS' +
                                   'KJTGVBLWSE' +
                                   'IGIRAFFESH' +
                                   'DSGKUIVGHE' +
                                   'IZEBRAVBOI' +
                                   'PWRIEVUOZW' +
                                   'XIPUCHZXPE' +
                                   'BELKUIVGSR')
;

INSERT INTO [Levels]
           ([Name]
           ,[Size]
           ,[Letters]
           )
     VALUES
	 		     ('Food', 1010, 'SFGHDFHDFH' +
                                'NUGGETSTRN' +
                                'TAEHIVPLCE' +
                                'VZXOIUAEWE' +
                                'ZBUTBNGHEO' +
                                'OUIDHBHDOI' +
                                'VNOODLESVR' +
                                'AWEGUVTDFV' +
                                'ZCURRYTBSE' +
                                'ERSLIPIZZA')
;

INSERT INTO [Solutions]
           ([LevelID]
           ,[Word]
           )
     VALUES
	 		     (2,'PIZZA')
;
INSERT INTO [Solutions]
           ([LevelID]
           ,[Word]
           )
     VALUES
	 		     (2,'SPAGHETTI')
;
INSERT INTO [Solutions]
           ([LevelID]
           ,[Word]
           )
     VALUES
	 		     (2,'NOODLES')
;
INSERT INTO [Solutions]
           ([LevelID]
           ,[Word]
           )
     VALUES
	 		     (2,'HOTDOG')
;
INSERT INTO [Solutions]
           ([LevelID]
           ,[Word]
           )
     VALUES
	 		     (2,'CURRY')
;
INSERT INTO [Solutions]
           ([LevelID]
           ,[Word]
           )
     VALUES
	 		     (2,'NUGGETS')
;

INSERT INTO [Solutions]
           ([LevelID]
           ,[Word]
           )
     VALUES
	 		     (1,'BULL')
;
INSERT INTO [Solutions]
           ([LevelID]
           ,[Word]
           )
     VALUES
	 		     (1,'ZEBRA')
;
INSERT INTO [Solutions]
           ([LevelID]
           ,[Word]
           )
     VALUES
	 		     (1,'TIGER')
;
INSERT INTO [Solutions]
           ([LevelID]
           ,[Word]
           )
     VALUES
	 		     (1,'GIRAFFE')
;
INSERT INTO [Solutions]
           ([LevelID]
           ,[Word]
           )
     VALUES
	 		     (1,'MONKEY')
;

INSERT INTO [History]
           ([UserID]
           ,[LevelID]
           ,[Time]
           ,[Score]
           )
     VALUES
	 		     (2,1, '00:05:34', 354)
;

INSERT INTO [History]
           ([UserID]
           ,[LevelID]
           ,[Time]
           ,[Score]
           )
     VALUES
	 		     (2,2, '00:07:54', 257)
;

INSERT INTO [History]
           ([UserID]
           ,[LevelID]
           ,[Time]
           ,[Score]
           )
     VALUES
	 		     (2,2, '00:03:29', 423)
;