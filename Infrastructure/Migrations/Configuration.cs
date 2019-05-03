namespace Infrastructure.Migrations
{
    using Infrastructure.DataContext;
    using Infrastructure.Entities;
    using Infrastructure.Identity;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MovieDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MovieDbContext context)
        {
            AddCategories(context);

            AddRole(context);

            AddUserAdmin(context);

            AddNguoiDung(context);

            AddResolution(context);

            AddProducer(context);

            AddTag(context);

            AddDirector(context);

            AddActor(context);
        }

        private void AddActor(MovieDbContext context)
        {
            if (!context.Actors.Any())
            {
                context.Actors.Add(new Actor()
                {
                    NameActor = "Robert Downey Jr.",
                    Thumbnail = "http://image.pmcontent.com/profile/17/medium.jpg",
                    Description = "Robert John Downey, Jr (sinh ngày 4 tháng 4 năm 1965) là một diễn viên người Mỹ. Ông sinh ra ở Thành phố New York, Hoa Kỳ. Ông diễn xuất từ khi mới 5 tuổi trong phim Pound của cha ông. Ông tham gia các phim như Less Than Zero'Less Than Zero, Air America, Natural Born Killers, Soapdish, ..."
                });
                context.Actors.Add(new Actor()
                {
                    NameActor = "Leonardo DiCaprio",
                    Thumbnail = "https://upload.wikimedia.org/wikipedia/commons/thumb/2/25/Leonardo_DiCaprio_2014.jpg/250px-Leonardo_DiCaprio_2014.jpg",
                    Description = "Leonardo Wilhelm DiCaprio ( /dɪˈkæpri.oʊ/; sinh ngày 11 tháng 11 năm 1974) ... Kể từ thập niên 2000, DiCaprio nhận được nhiều khen ngợi trong sự nghiệp."
                });
                context.Actors.Add(new Actor()
                {
                    NameActor = "Will Smith",
                    Thumbnail = "http://www.gstatic.com/tv/thumb/persons/1650/1650_v9_ba.jpg",
                    Description = "Willard Christopher 'Will' Smith, Jr. (sinh ngày 25 tháng 9, năm 1968) là một diễn viên, rapper, nhà sản xuất và nhạc sĩ người Mỹ. Tháng 4 năm 2007, Newsweek đã xem xét ông là 'nam diễn viên quyền lực nhất Hollywood'. Smith đã được đề cử cho năm giải thưởng Quả Cầu Vàng và hai giải thưởng của Viện Hàn lâm, và đã giành được bốn giải Grammy."
                });
                context.Actors.Add(new Actor()
                {
                    NameActor = "Johnny Depp",
                    Thumbnail = "https://upload.wikimedia.org/wikipedia/commons/b/b4/Johnny_Depp_2016.jpg",
                    Description = "John Christopher Depp II là diễn viên người Mỹ từng ba lần được đề cử giải Oscar, nổi tiếng nhất với các vai diễn Jack Sparrow trong năm bộ phim Cướp biển vùng Carribe. Depp còn có nhiều bộ phim nổi tiếng như Edward the Scissorhands, Sweeney Todd: The Demon Barber of Fleet Street, Alice in Wonderland..."
                });
                context.Actors.Add(new Actor()
                {
                    NameActor = "Samuel L. Jackson",
                    Thumbnail = "http://www.gstatic.com/tv/thumb/persons/71048/71048_v9_ba.jpg",
                    Description = "Samuel Leroy Jackson là một diễn viên kiêm nhà sản xuất phim và chương trình truyền hình người Mỹ. Ông đã có một số vai diễn nhỏ ví dụ như trong phim Goodfellas trước khi gặp 'người thầy' Morgan Freeman và đạo diễn Spike Lee."
                });
                context.Actors.Add(new Actor()
                {
                    NameActor = "Matt Damon",
                    Thumbnail = "http://www.gstatic.com/tv/thumb/persons/44333/44333_v9_ba.jpg",
                    Description = "Matthew Paige Damon, hay Matt Damon, là một nam diễn viên, nhà sản xuất phim và biên kịch người Mỹ. Anh được tạp chí Forbes bình chọn là một trong những ngôi sao bảo chứng doanh thu và là một trong những diễn viên được trả thù lao cao nhất mọi thời đại."
                });
                context.Actors.Add(new Actor()
                {
                    NameActor = "Brad Pitt",
                    Thumbnail = "https://static1.dienanh.net/upload/2015/03/26/brad-pitt-26643.jpg",
                    Description = "Brad Pitt tên thật là William Bradley Pitt sinh ngày 18 tháng 12 năm 1963 tại là diễn viên và nhà sản xuất phim người Mỹ. Brad Pitt được bình chọn là một trong những người đàn ông hấp dẫn nhất thế giới. Brad từng nhận được ba đề cử cho giải Oscar và nhận được một giải Quả cầu vàng. "
                });
                context.Actors.Add(new Actor()
                {
                    NameActor = "Denzel Washington",
                    Thumbnail = "https://upload.wikimedia.org/wikipedia/commons/thumb/c/ca/Denzel_Washington_cropped.jpg/200px-Denzel_Washington_cropped.jpg",
                    Description = "Denzel Hayes Washington, Jr., thường được biết đến với tên Denzel Washington là một diễn viên rất nổi tiếng của điện ảnh Mỹ. Cho đến nay Washington đã có tổng cộng hai tượng vàng Oscar trên 6 lần đề cử và 3 giải Quả cầu vàng."
                });
                context.Actors.Add(new Actor()
                {
                    NameActor = "Christian Bale",
                    Thumbnail = "https://upload.wikimedia.org/wikipedia/commons/thumb/1/1e/ChristianBaleJun09.jpg/250px-ChristianBaleJun09.jpg",
                    Description = "Christian Bale là một diễn viên người Anh. Được biết đến qua các vai trong phim như American Psycho, Shaft, Equilibrium, The Machinist, Batman begins, và The Prestige."
                });
                context.Actors.Add(new Actor()
                {
                    NameActor = "George Clooney",
                    Thumbnail = "https://upload.wikimedia.org/wikipedia/commons/thumb/8/8d/George_Clooney_2016.jpg/250px-George_Clooney_2016.jpg",
                    Description = "George Timothy Clooney là một diễn viên, đạo diễn, nhà sản xuất phim, biên kịch và doanh nhân người Mỹ. Ông từng nhận ba giải thưởng Quả Cầu Vàng với vai trò là diễn viên và hai giải Oscar, một giải cho vai diễn trong bộ phim Syriana, một giải với vai trò là nhà sản xuất của bộ phim Argo."
                });
                context.Actors.Add(new Actor()
                {
                    NameActor = "Nicole Kidman",
                    Thumbnail = "https://upload.wikimedia.org/wikipedia/commons/thumb/2/28/Nicole_Kidman_Cannes_2017_2.jpg/250px-Nicole_Kidman_Cannes_2017_2.jpg",
                    Description = "Nicole Mary Kidman là một nữ diễn viên, ca sĩ và nhà sản xuất phim người Úc. Vai diễn bứt phá của Kidman là trong bộ phim Dead Calm năm 1989. Sau một số bộ phim đầu thập niên 1990, cô nổi tiếng toàn thế giới nhờ phần diễn xuất trong phim Days of Thunder, Far and Away, và Batman Forever."
                });
                context.Actors.Add(new Actor()
                {
                    NameActor = "Cate Blanchett",
                    Thumbnail = "http://www.gstatic.com/tv/thumb/persons/70375/70375_v9_ba.jpg",
                    Description = "Catherine Élise 'Cate' Blanchett, sinh ngày 14 tháng 5 năm 1969, là một nữ diễn viên điện ảnh nổi tiếng người Úc. Cô đã từng nhận rất nhiều giải thưởng danh giá, trong đó có ngôi sao trên Đại lộ Danh vọng Hollywood, 2 giải Screen Actors Guild, 2 giải Quả cầu Vàng, 2 giải BAFTA và 2 giải Oscar."
                });

                context.SaveChanges();
            }
        }

        private void AddDirector(MovieDbContext context)
        {
            if (!context.Directors.Any())
            {
                context.Directors.Add(new Director()
                {
                    NameDirector = "Steven Spielberg",
                    Thumbnail = "http://www.gstatic.com/tv/thumb/persons/1672/1672_v9_ba.jpg",
                    Description = "Steven Allan Spielberg (sinh ngày 18 tháng 12 năm 1946) là một nhà làm phim người Mỹ.<br />Steven Allan Spielberg là một nhà làm phim người Mỹ. Ông được coi là một trong những người tiên phong của kỷ nguyên điện ảnh New Hollywood và là một trong những đạo diễn và nhà sản xuất điện ảnh nổi tiếng nhất trong lịch sử."
                });
                context.Directors.Add(new Director()
                {
                    NameDirector = "James Cameron",
                    Thumbnail = "https://upload.wikimedia.org/wikipedia/commons/thumb/c/cd/JamesCameronHWOFOct2012.jpg/300px-JamesCameronHWOFOct2012.jpg",
                    Description = "James Francis Cameron (sinh ngày 16 tháng 8 năm 1954 tại Kapuskasing, Ontario, Canada) là đạo diễn người Mỹ gốc Canada. James Francis Cameron là đạo diễn người Mỹ gốc Canada. Năm 1971, ông chuyển sang sinh sống ở Mỹ và đã tốt nghiệp khoa Vật lý Đại học California. Ông được biết đến như một đạo diễn điện ảnh có nhiều tên tuổi trên thế giới."
                });
                context.Directors.Add(new Director()
                {
                    NameDirector = "Christopher Nolan",
                    Thumbnail = "https://upload.wikimedia.org/wikipedia/commons/thumb/9/95/Christopher_Nolan_Cannes_2018.jpg/250px-Christopher_Nolan_Cannes_2018.jpg",
                    Description = "Christopher Edward Nolan ( /ˈnoʊlən/; sinh ngày 30 tháng 7 năm 1970) là một đạo diễn, nhà biên kịch và nhà sản xuất điện ảnh người Anh. Christopher Edward Nolan là một đạo diễn, nhà biên kịch và nhà sản xuất điện ảnh người Anh. Ông sở hữu cả hai quốc tịch Anh và Mỹ. Nolan là một trong những đạo diễn ăn khách nhất lịch sử, đồng thời là một trong những nhà làm phim được hoan nghênh nhất và có tầm ảnh hưởng lớn nhất của thế kỉ 21."
                });
                context.Directors.Add(new Director()
                {
                    NameDirector = "Christopher Edward Nolan là một đạo diễn, nhà biên kịch và nhà sản xuất điện ảnh người Anh. Ông sở hữu cả hai quốc tịch Anh và Mỹ. Nolan là một trong những đạo diễn ăn khách nhất lịch sử, đồng thời là một trong những nhà làm phim được hoan nghênh nhất và có tầm ảnh hưởng lớn nhất của thế kỉ 21.",
                    Thumbnail = "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d8/Tim_Burton_by_Gage_Skidmore.jpg/220px-Tim_Burton_by_Gage_Skidmore.jpg",
                    Description = "Timothy Walter 'Tim' Burton (sinh ngày 25 tháng 8 năm 1958) là đạo diễn, nhà ... phác thảo, nháp hay ý tưởng mang tên The Art of Tim Burton vào năm 2009. Timothy Walter 'Tim' Burton là đạo diễn, nhà sản xuất, nhà văn, nhà thơ và nghệ sĩ và nghệ sĩ hoạt hình động người Mỹ."
                });
                context.Directors.Add(new Director()
                {
                    NameDirector = "Quentin Tarantino",
                    Thumbnail = "http://www.gstatic.com/tv/thumb/persons/52431/52431_v9_ba.jpg",
                    Description = "Quentin Jerome Tarantino (phát âm /ˌtærənˈtiːnoʊ/; sinh 27 tháng 3 năm 1963) là đạo diễn phim, nhà viết kịch bản, nhà sản xuất, và diễn viên người Mỹ. Quentin Jerome Tarantino là đạo diễn phim, nhà viết kịch bản, nhà sản xuất, và diễn viên người Mỹ. Các nét đặc trưng trong phim của ông nằm ở cốt truyện phi tuyến tính, các đề tài châm biếm và sự thẩm mỹ hoá/ tôn vinh bạo lực thường dẫn đến các đặc trưng của phim neo-noir."
                });
                context.Directors.Add(new Director()
                {
                    NameDirector = "Chris Columbus",
                    Thumbnail = "http://www.gstatic.com/tv/thumb/persons/86548/86548_v9_bb.jpg",
                    Description = "Chris Joseph Columbus 10 tháng 9, 1958 (60 tuổi) Spangler, Pennsylvania, Hoa Kỳ. Nơi cư trú, Pacific Heights, San Francisco, California. Christopher Columbus là nhà làm phim Mỹ gốc Ý và Séc."
                });
                context.Directors.Add(new Director()
                {
                    NameDirector = "Michael Bay",
                    Thumbnail = "http://www.gstatic.com/tv/thumb/persons/70807/70807_v9_ba.jpg",
                    Description = "Michael Benjamin Bay (sinh 17 tháng 2 1965) là một đạo diễn kiêm nhà sản xuất phim người Mỹ. Bay nổi tiếng với những bộ phim có kinh phí lớn như Armageddon, The Rock, Bad Boys Bad Boys, Bad Boys II, Transformers, Transformers: Revenge of the Fallen, Transformers: Dark of the Moon, Transformers: Age of Extinction."
                });
                context.Directors.Add(new Director()
                {
                    NameDirector = "Peter Jackson",
                    Thumbnail = "http://www.gstatic.com/tv/thumb/persons/154972/154972_v9_bb.jpg",
                    Description = "Hiệp Sĩ Peter Robert Jackson (sinh 17 tháng 2 1965) là một đạo diễn, nhà sản xuất, diễn viên, biên kịch người New Zealand, ông nổi tiếng với loạt phim Chúa tể của những chiếc nhẫn, chuyển thể từ tiểu thuyết của nhà văn J. R. R. Tolkien. Ông cũng được biết đến với bộ phim làm lại King Kong và là nhà sản xuất của Khu vực 9. "
                });
                context.Directors.Add(new Director()
                {
                    NameDirector = "Scarlett Johansson",
                    Thumbnail = "https://upload.wikimedia.org/wikipedia/commons/thumb/c/c5/Scarlett_Johansson_in_Kuwait_01b-tweaked.jpg/250px-Scarlett_Johansson_in_Kuwait_01b-tweaked.jpg",
                    Description = "Scarlett Johansson (sinh ngày 22 tháng 11 năm 1984) là một nữ diễn viên, người mẫu và ca sĩ người Mỹ. Cô xuất hiện lần đầu tiên dưới vai trò một diễn viên điện ảnh ở trong bộ phim North khi chỉ mới 10 tuổi, và sau đó tiếp tục sự nghiệp với Manny & Lo, và bắt đầu gây được chú ý từ công chúng qua các vai diễn trong The Horse Whisperer và Ghost World."
                });
                context.Directors.Add(new Director()
                {
                    NameDirector = "Tom Hanks",
                    Thumbnail = "https://upload.wikimedia.org/wikipedia/commons/thumb/d/de/TomHanksApr09.jpg/250px-TomHanksApr09.jpg",
                    Description = "Thomas Jeffrey Hanks (sinh ngày 9 tháng 7 năm 1956) là diễn viên, đạo diễn, nhà sản xuất phim người Mỹ nổi tiếng. Ông từng đoạt 2 giải Oscar cho các vai diễn trong phim Philadelphia và Forrest Gump."
                });

                context.SaveChanges();
            }
        }

        private void AddTag(MovieDbContext context)
        {
            if (!context.Tags.Any())
            {
                context.Tags.Add(new Tag()
                {
                    NameTag = "tội phạm"
                });
                context.Tags.Add(new Tag()
                {
                    NameTag = "marvel"
                });
                context.Tags.Add(new Tag()
                {
                    NameTag = "tình yêu"
                });
                context.Tags.Add(new Tag()
                {
                    NameTag = "phim ma"
                });
                context.Tags.Add(new Tag()
                {
                    NameTag = "cảnh sát"
                });
                context.Tags.Add(new Tag()
                {
                    NameTag = "ma cà rồng"
                });
                context.Tags.Add(new Tag()
                {
                    NameTag = "xác sống"
                });
                context.Tags.Add(new Tag()
                {
                    NameTag = "kdrama"
                });
                context.Tags.Add(new Tag()
                {
                    NameTag = "người ngoài hành tinh"
                });
                context.Tags.Add(new Tag()
                {
                    NameTag = "zombie"
                });
                context.Tags.Add(new Tag()
                {
                    NameTag = "siêu nhân"
                });
                context.Tags.Add(new Tag()
                {
                    NameTag = "siêu anh hùng"
                });
                context.Tags.Add(new Tag()
                {
                    NameTag = "phim viễn tưởng hay"
                });
                context.Tags.Add(new Tag()
                {
                    NameTag = "quái vật"
                });
                context.Tags.Add(new Tag()
                {
                    NameTag = "tận thế"
                });
                context.Tags.Add(new Tag()
                {
                    NameTag = "sát thủ"
                });
                context.Tags.Add(new Tag()
                {
                    NameTag = "phim viễn tưởng chọn lọc"
                });
                context.Tags.Add(new Tag()
                {
                    NameTag = "người máy"
                });
                context.Tags.Add(new Tag()
                {
                    NameTag = "phù thủy"
                });
                context.Tags.Add(new Tag()
                {
                    NameTag = "châu tinh trì"
                });
                context.Tags.Add(new Tag()
                {
                    NameTag = "thảm họa"
                });
                context.Tags.Add(new Tag()
                {
                    NameTag = "xã hội đen"
                });
                context.Tags.Add(new Tag()
                {
                    NameTag = "thây ma"
                });
                context.Tags.Add(new Tag()
                {
                    NameTag = "robot"
                });
                context.Tags.Add(new Tag()
                {
                    NameTag = "thám tử"
                });
                context.Tags.Add(new Tag()
                {
                    NameTag = "điệp viên"
                });
                context.Tags.Add(new Tag()
                {
                    NameTag = "khủng bố"
                });
                context.Tags.Add(new Tag()
                {
                    NameTag = "trinh thám"
                });

                context.SaveChanges();
            }
        }

        private void AddProducer(MovieDbContext context)
        {
            if (!context.Producers.Any())
            {
                context.Producers.Add(new Producer()
                {
                    NameProducer = "Marvel Studios",
                    Thumbnail = "~/Images/producer/1.jpg",
                    Description = "Không quá khó hiểu khi Marvel Studios được xướng tên trong danh sách này, khi mà chưa đầy 10 năm hãng này đã 'cá kiếm' về xấp xỉ 14 tỷ đô la với chỉ một dòng phim duy nhất về những siêu anh hùng. Marvel Studios đã từng có một khoảng thời gian vô cùng khó khăn khi đã từng phải bán rất nhiều bản quyền các nhân vật của hãng vì làm ăn thua lỗ, tuy nhiên kể từ năm 2008 đến nay Marvel Studios đã gặt hái được không ít thành công và là nơi đi đầu cho khái niệm về dòng phim 'vũ trụ điện ảnh', vậy nên không khó có thể nhận thấy hiện nay trên thế giới hay tại Việt Nam cũng đều có đông đạo những người hâm của những hình tượng nhân vật mà họ tạo dựng"
                });
                context.Producers.Add(new Producer()
                {
                    NameProducer = "Warner Bros",
                    Thumbnail = "~/Images/producer/2.jpg",
                    Description = "Warner Bros hay còn được gọi là Warner Brothers Pictures, thành lập vào năm 1918 bởi 4 anh em người nhập cư là Jack, Abe, Sam và Harry, phát triển từ những ngày đầu không mấy tên tuổi và chủ yếu tập trung và dòng phim câm cho đến ngày nay đã trở thành hãng phim lớn mạnh, vươn tầm ảnh hưởng của mình lên nhiều lĩnh vực, đây cũng là hãng phim đã đặt nền móng cho ngành phim nói."
                });
                context.Producers.Add(new Producer()
                {
                    NameProducer = "Universal Pictures",
                    Thumbnail = "~/Images/producer/3.jpg",
                    Description = "Universal Pictures là công ty con của NBC Universal, là hãng phim lâu đời thứ 2 trên thế giới và đồng thời cũng được coi là một trong 6 xưởng phim lớn nhất. Được thành lập năm 1912 bởi Carl Laemmle, cho đến nay hãng này đã có trên 200 bộ phim ở các thể loại khác nhau, luôn tạo ra những bộ phim mang chất riêng, mang tính độc đáo và luôn tạo nên những bộ phim đa dạng khác nhau. Chính vì thế, hãng phim này luôn là nơi thu hút được đông đảo fan hâm mộ từ nhiều lứa tuổi khác nhau."
                });
                context.Producers.Add(new Producer()
                {
                    NameProducer = "Walt Disney Studios Motion Pictures",
                    Thumbnail = "~/Images/producer/4.jpg",
                    Description = "Walt Disney có lẽ không còn là một cái tên quá xa lạ đối với những ai có tuổi thơ gắn chặt với những hình tượng cổ tích, điển hình là chú chuột Mickey. Trực thuộc The Walt Disney Company, hãng được thành lập năm 1953 với tên gọi Buena Vista Distribution Company, công ty chuyên thực hiện công việc phát hành các bộ phim do Walt Disney Studios sản xuất bao gồm Walt Disney Pictures, Touchstone Pictures, Disneynature. Đây cũng được coi là hãng phim chính duy nhất tại Hollywood khi mà có rất nhiều bộ của hãng cán mốc 1 tỷ usd."
                });
                context.Producers.Add(new Producer()
                {
                    NameProducer = "20th Century Fox",
                    Thumbnail = "~/Images/producer/5.jpg",
                    Description = "20th Century Fox hay chỉ đơn giản gọi là Fox, được thành lập năm 28 tháng 12 năm 1934, là kết quả của sự hợp nhất Fox Film Corporation sáng lập bởi William Fox năm 1915. Tọa lạc tại Century City ở Los Angeles, phía Tây Beverly Hills, không khó có thể nhận ra đây là thương hiệu khá quen thuộc của nhiều thế hệ, và đây cũng là tiền đề cho sự ra đời của nhiều dòng phim kinh điển và điển hình nhất là dòng phim star wars đình đám."
                });
                context.Producers.Add(new Producer()
                {
                    NameProducer = "Paramount Pictures",
                    Thumbnail = "~/Images/producer/6.jpg",
                    Description = "Được coi là hãng phim lâu đời nhất trên thế giới khi mà trong hơn 100 năm qua ngọn núi của Paramount Pictures vẫn  đứng vững và trở thành một trong những trụ cột của điện ảnh Hollywood, đây cũng là hãng phim duy nhất vẫn còn đặt trụ sở tại mảnh đất phồn hoa này. Được hình thành vào năm 1912 và hiện tại đang được sở hữu bởi tập đoàn Viacom, đến nay Paramount Pictures đã tích lũy được cả một kho tàng phim gắn bó với văn hóa đại chúng qua nhiều thế hệ."
                });
                context.Producers.Add(new Producer()
                {
                    NameProducer = "Sony Pictures Studios",
                    Thumbnail = "~/Images/producer/7.jpg",
                    Description = "Hoạt động như một công ty con của Sony Entertainment Inc, được thành lập vào năm 1987, Sony Picture thực ra không có quá nhiều nền tảng như những hãng phim khác. Tuy nhiên đây vẫn là một trong những hãng phim lớn của Hollywood và là thành viên của Hiệp hội Điện ảnh Hoa Kỳ. Sony Pictures chuyên về sản xuất, mua lại và phân phối các bộ phim giải trí. "
                });
                context.Producers.Add(new Producer()
                {
                    NameProducer = "Pixar",
                    Thumbnail = "~/Images/producer/8.jpg",
                    Description = "Pixar được biết đến như một hãng phim hoạt hình có những thước phim hoạt hình 3D sử dụng công nghệ tạo hình máy tính của riêng hãng, từ đó đem đến cho khán giả những bộ phim hoạt hình với chất lượng hình ảnh cao và đẹp mắt. Cùng với đó là chất lượng nội dung mang tính nhân văn cao, do vậy có rất nhiều bộ phim của hãng nhận được những giải thưởng danh giá, cụ thể hãng đã 15 lần nhận giải Oscar, 7 lần nhận giải Quả cầu vàng và 11 lần nhận giải Grammy Award."
                });
                context.Producers.Add(new Producer()
                {
                    NameProducer = "Dream Works",
                    Thumbnail = "~/Images/producer/9.jpg",
                    Description = "Cũng được xem như là một hãng phim danh tiếng trong làng phim hoạt hình hiện nay, Dream Works bắt đầu hoạt động từ năm 1994 và được điều hành bởi Steven Spielberg, Jeffrey Katzenberg và David Geffen. Những bộ phim của Dream Works khác biệt so với những hãng khác ở nét vẽ mạnh mẽ, phóng khoáng. Nội dung nhấn mạnh yếu tố hài hước, phiêu lưu hợp với khán giả nhí, từ đó tạo ra một nét độc đáo mà chỉ Dream Works tạo ra được. Hiện tại hãng phim này cũng đã về dưới trướng của tập đoàn Viacom."
                });
                context.Producers.Add(new Producer()
                {
                    NameProducer = "Columbia Pictures",
                    Thumbnail = "~/Images/producer/10.jpg",
                    Description = "Columbia Pictures hiện cũng là một công ty con của Sony Pictures Entertainment, xưởng phim được thành lập năm 1919 bởi anh em Jack Cohn và Harry Cohn cùng với Joe Brandt. Logo một người phụ nữ Hy Lạp cầm ngọn đuốc nâng cao qua đầu có lẽ không còn là một biểu tượng quá xa lạ, khi mà hãng phim này có rất nhiều bộ phim tuy không quá nổi trội nhưng vẫn đi vào lòng những người mộ đạo điện ảnh theo từng năm tháng."
                });

                context.SaveChanges();
            }
        }

        private void AddUserAdmin(MovieDbContext context)
        {
            if (!context.Users.Any(t => t.UserName == "QuanLy"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser
                {
                    UserName = "admin@gmail.com",
                    Email = "admin@gmail.com",
                    FullName = "Người quản lý",
                    CreatedDate = DateTime.Now,
                    PhoneNumber = "19001001"
                };

                manager.Create(user, "123456");
                manager.AddToRole(user.Id, "Admin");
                manager.AddToRole(user.Id, "User");

                context.SaveChanges();
            }
        }

        private void AddNguoiDung(MovieDbContext context)
        {
            if (!context.Users.Any(t => t.UserName == "NguoiDung"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser
                {
                    UserName = "nguoidung@gmail.com",
                    Email = "nguoidung@gmail.com",
                    FullName = "Người dùng",
                    CreatedDate = DateTime.Now,
                    PhoneNumber = "19001001"
                };

                manager.Create(user, "123456");
                manager.AddToRole(user.Id, "User");

                context.SaveChanges();
            }
        }

        private void AddResolution(MovieDbContext context)
        {
            if (!context.Resolutions.Any())
            {
                context.Resolutions.Add(new Resolution()
                {
                    NameResolution = "144p"
                });
                context.Resolutions.Add(new Resolution()
                {
                    NameResolution = "240p"
                });
                context.Resolutions.Add(new Resolution()
                {
                    NameResolution = "360p"
                });
                context.Resolutions.Add(new Resolution()
                {
                    NameResolution = "480p"
                });
                context.Resolutions.Add(new Resolution()
                {
                    NameResolution = "720p"
                });
                context.Resolutions.Add(new Resolution()
                {
                    NameResolution = "1080p"
                });
                context.Resolutions.Add(new Resolution()
                {
                    NameResolution = "1440p"
                });
                context.Resolutions.Add(new Resolution()
                {
                    NameResolution = "2160p"
                });

                context.SaveChanges();
            }
        }

        private void AddRole(MovieDbContext context)
        {
            if (!context.Roles.Any(t => t.Name == "Admin" && t.Name == "User"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var roleAdmin = new IdentityRole { Name = "Admin" };
                var roleUse = new IdentityRole { Name = "User" };

                manager.Create(roleAdmin);
                manager.Create(roleUse);

                context.SaveChanges();
            }
        }

        private void AddCategories(MovieDbContext context)
        {
            if (!context.Categories.Any())
            {
                context.Categories.Add(new Entities.Category()
                {
                    NameCategory = "Phim hành động"
                });
                context.Categories.Add(new Entities.Category()
                {
                    NameCategory = "Phim viễn tưởng"
                });
                context.Categories.Add(new Entities.Category()
                {
                    NameCategory = "Phim chiến tranh"
                });
                context.Categories.Add(new Entities.Category()
                {
                    NameCategory = "Phim hình sự"
                });
                context.Categories.Add(new Entities.Category()
                {
                    NameCategory = "Phim phiêu lưu"
                });
                context.Categories.Add(new Entities.Category()
                {
                    NameCategory = "Phim hài hước"
                });
                context.Categories.Add(new Entities.Category()
                {
                    NameCategory = "Phim võ thuật"
                });
                context.Categories.Add(new Entities.Category()
                {
                    NameCategory = "Phim kinh dị"
                });
                context.Categories.Add(new Entities.Category()
                {
                    NameCategory = "Phim hồi hộp-Gây cấn"
                });
                context.Categories.Add(new Entities.Category()
                {
                    NameCategory = "Phim Bí ẩn-Siêu nhiên"
                });
                context.Categories.Add(new Entities.Category()
                {
                    NameCategory = "Phim cổ trang"
                });
                context.Categories.Add(new Entities.Category()
                {
                    NameCategory = "Phim thần thoại"
                });
                context.Categories.Add(new Entities.Category()
                {
                    NameCategory = "Phim tâm lý"
                });
                context.Categories.Add(new Entities.Category()
                {
                    NameCategory = "Phim tài liệu"
                });
                context.Categories.Add(new Entities.Category()
                {
                    NameCategory = "Phim tình cảm-Lãng mạn"
                });
                context.Categories.Add(new Entities.Category()
                {
                    NameCategory = "Phim chính kịch - Drama"
                });
                context.Categories.Add(new Entities.Category()
                {
                    NameCategory = "Phim Thể thao-Âm nhạc"
                });
                context.Categories.Add(new Entities.Category()
                {
                    NameCategory = "Phim gia đình"
                });
                context.Categories.Add(new Entities.Category()
                {
                    NameCategory = "Phim hoạt hình"
                });

                context.SaveChanges();
            }
        }


    }
}
