FROM mcr.microsoft.com/dotnet/sdk:6.0 as init

# FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch as debug
FROM mcr.microsoft.com/dotnet/sdk:6.0 as debug
RUN mkdir /work/
WORKDIR /work/


ENV ASPNETCORE_ENVIRONMENT=Development 

# # IF is new proyect comment 2 lines below
# COPY ./src/work.csproj /work/work.csproj
# RUN dotnet restore
# COPY ./src/ /work/
RUN mkdir /out/
# RUN dotnet publish --no-restore --output /out/ --configuration Release

#install debugger from Net Core
RUN apt-get update
RUN apt-get install -y unzip
RUN curl -sSL https://aka.ms/getvsdbgsh | /bin/sh /dev/stdin -v latest -l /vsdbg
# Install manual debugger NetCore
# curl -L -o GetVsDbg.sh https://aka.ms/getvsdbgsh 
# sh GetVsDbg.sh -v latest -l /vsdbg

#  dotnet dev-certs https --clean
#  dotnet dev-certs https -t
#  CMD dotnet run

# Install Zsh to make life easier
RUN ["apt-get", "update"]
RUN ["apt-get", "install", "-y", "zsh"]
RUN wget https://github.com/robbyrussell/oh-my-zsh/raw/master/tools/install.sh -O - | zsh || true
# CMD ["zsh"]
CMD [ "zsh && source ~/.zshrc" ]

# Install Node
EXPOSE 80
EXPOSE 443
RUN apt-get update
RUN apt-get install -y curl
RUN apt-get install -y libpng-dev libjpeg-dev curl libxi6 build-essential libgl1-mesa-glx
RUN curl -sL https://deb.nodesource.com/setup_lts.x | bash -
RUN apt-get install -y nodejs


# Start New Image #
FROM mcr.microsoft.com/dotnet/sdk:3.1-bullseye-arm64v8 as prod
# FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim as prod

RUN mkdir /app/
WORKDIR /app/
COPY --from=dev /out/ /app/
RUN chmod +x /app/
CMD dotnet work.dll


